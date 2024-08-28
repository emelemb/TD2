using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD2.Managers;

namespace TD2;

public class CatmullRomPath
{
    private class TriangleStripBuffer
    {
        private VertexBuffer buffer;

        private BasicEffect effect;

        private int nbrVertices;

        public void Update(GraphicsDevice device, VertexPositionTexture[] vertices)
        {
            buffer = new VertexBuffer(device, typeof(VertexPositionTexture), vertices.Length, BufferUsage.WriteOnly);
            buffer.SetData(vertices);
            nbrVertices = vertices.Length;
            float num = device.Viewport.Width;
            float num2 = device.Viewport.Height;
            effect = new BasicEffect(device)
            {
                World = Matrix.Identity,
                View = Matrix.CreateLookAt(new Vector3(num / 2f, num2 / 2f, -10f), new Vector3(num / 2f, num2 / 2f, 0f), -Vector3.Up),
                Projection = Matrix.CreateOrthographic(num, num2, 1f, 10f)
            };
        }

        public bool IsValid()
        {
            return buffer != null;
        }

        public void Draw(GraphicsDevice device, Texture2D texture)
        {
            device.BlendState = BlendState.AlphaBlend;
            device.DepthStencilState = DepthStencilState.Default;
            device.SamplerStates[0] = SamplerState.LinearWrap;
            effect.Texture = texture;
            effect.TextureEnabled = true;
            effect.CurrentTechnique.Passes[0].Apply();
            device.SetVertexBuffer(buffer);
            device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, nbrVertices - 2);
        }
    }

    private List<Vector2> controlPoints;

    private float t;

    private Texture2D texture_controlPoints;

    private TriangleStripBuffer tristripBuffer;

    public CatmullRomPath(GraphicsDevice gd, float tension = 0.5f)
    {
        if (tension < 0f || tension > 10f)
        {
            throw new ArgumentException("@tension must be in the [0,1] range");
        }

        controlPoints = new List<Vector2>();
        t = tension;
        texture_controlPoints = new Texture2D(gd, 1, 1, mipmap: false, SurfaceFormat.Color);
        tristripBuffer = new TriangleStripBuffer();
        Clear();
    }

    public void AddPoint(Vector2 point)
    {
        controlPoints.Insert(controlPoints.Count - 1, point);
        UpdateEndPoints();
    }

    public void SetPoint(int i, Vector2 point)
    {
        if (i < 0 || i > controlPoints.Count - 2)
        {
            throw new ArgumentException("i out of bounds");
        }

        controlPoints[i + 1] = point;
        UpdateEndPoints();
    }

    public Vector2[] GetPoints()
    {
        Vector2[] array = new Vector2[controlPoints.Count - 2];
        for (int i = 1; i < controlPoints.Count - 1; i++)
        {
            array[i - 1] = controlPoints[i];
        }

        return array;
    }

    public void Clear()
    {
        controlPoints.Clear();
        controlPoints.Add(default(Vector2));
        controlPoints.Add(default(Vector2));
    }

    public Vector2 EvaluateAt(float x)
    {
        if (controlPoints.Count < 4)
        {
            throw new InvalidOperationException("Must add at least two control points");
        }

        if (x < 0f || x > 1f)
        {        
            throw new ArgumentException("@x must be in the [0,1] range");
        }

        float num = x * (float)(controlPoints.Count - 3);
        int num2 = (int)Math.Floor(num);
        float x2;
        if (x < 1f)
        {
            x2 = num - (float)num2;
        }
        else
        {
            num2--;
            x2 = 1f;
        }

        return EvalCatmullRomSpline(controlPoints[num2], controlPoints[num2 + 1], controlPoints[num2 + 2], controlPoints[num2 + 3], x2, t);
    }


    public Vector2 EvaluateTangentAt(float x)
    {
        if (controlPoints.Count < 4)
        {
            throw new InvalidOperationException("Must add at least two control points");
        }

        if (x < 0f || x > 1.1f)
        {
            throw new ArgumentException("@x must be in the [0,1] range");
        }

        float num = x * (float)(controlPoints.Count - 3);
        int num2 = (int)Math.Floor(num);
        float x2;
        if (x < 1f)
        {
            x2 = num - (float)num2;
        }
        else
        {
            num2--;
            x2 = 1f;
        }

        return EvalCatmullRomSplineTangent(controlPoints[num2], controlPoints[num2 + 1], controlPoints[num2 + 2], controlPoints[num2 + 3], x2, t);
    }

    public void DrawPoints(SpriteBatch sb, Color color, int size)
    {
        if (controlPoints.Count < 4)
        {
            throw new InvalidOperationException("Must add at least two control points");
        }

        texture_controlPoints.SetData(new Color[1] { color });
        sb.Begin();
        for (int i = 1; i < controlPoints.Count - 1; i++)
        {
            sb.Draw(position: new Vector2((int)controlPoints[i].X, (int)controlPoints[i].Y), origin: new Vector2(0.5f, 0.5f), scale: new Vector2(size, size), texture: texture_controlPoints, sourceRectangle: null, color: Color.White, rotation: 0f, effects: SpriteEffects.None, layerDepth: 1f);
        }

        sb.End();
    }

    public void DrawFillSetup(GraphicsDevice device, uint radius, uint textureRepeat = 1u, uint subdivisions = 256u)
    {
        if (controlPoints.Count < 4)
        {
            throw new InvalidOperationException("Must add at least two control points");
        }

        VertexPositionTexture[] array = new VertexPositionTexture[2 * subdivisions];
        for (int i = 0; i < subdivisions; i++)
        {
            float num = (float)i / (float)(subdivisions - 1);
            Vector2 vector = EvaluateAt(num);
            Vector2 vector2 = EvaluateTangentAt(num);
            Vector2 vector3 = new Vector2(vector2.Y, 0f - vector2.X);
            vector3.Normalize();
            Vector2 vector4 = vector - radius * vector3;
            Vector2 vector5 = vector + radius * vector3;
            Vector3 position = new Vector3(vector4.X, vector4.Y, 0f);
            Vector3 position2 = new Vector3(vector5.X, vector5.Y, 0f);
            Vector2 textureCoordinate = new Vector2(0f, num * (float)textureRepeat);
            Vector2 textureCoordinate2 = new Vector2(1f, num * (float)textureRepeat);
            array[2 * i] = new VertexPositionTexture(position, textureCoordinate);
            array[2 * i + 1] = new VertexPositionTexture(position2, textureCoordinate2);
        }

        tristripBuffer.Update(device, array);
    }

    public void DrawFill(GraphicsDevice device, Texture2D texture)
    {
        if (controlPoints.Count < 4)
        {
            throw new InvalidOperationException("Must add at least two control points");
        }

        if (!tristripBuffer.IsValid())
        {
            throw new InvalidOperationException("Call DrawFillSetup before Draw");
        }

        tristripBuffer.Draw(device, texture);
    }

    private void UpdateEndPoints()
    {
        if (controlPoints.Count >= 4)
        {
            int count = controlPoints.Count;
            controlPoints[0] = controlPoints[1] + 0.5f * (controlPoints[1] - controlPoints[2]);
            controlPoints[count - 1] = controlPoints[count - 2] + 0.5f * (controlPoints[count - 2] - controlPoints[count - 3]);
        }
    }

    private Vector2 EvalCatmullRomSpline(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float x, float t)
    {
        float num = x * x;
        float num2 = num * x;
        return p0 * ((0f - t) * x + 2f * t * num - t * num2) + p1 * (1f + (t - 3f) * num + (2f - t) * num2) + p2 * (t * x + (3f - 2f * t) * num + (t - 2f) * num2) + p3 * ((0f - t) * num + t * num2);
    }

    private Vector2 EvalCatmullRomSplineTangent(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float x, float t)
    {
        float num = x * x;
        return p0 * (0f - t + 4f * t * x - 3f * t * num) + p1 * (2f * (t - 3f) * x + 3f * (2f - t) * num) + p2 * (t + 2f * (3f - 2f * t) * x + 3f * (t - 2f) * num) + p3 * (-2f * t * x + 3f * t * num);
    }

    public void DrawMovingObject(float curve_curpos, SpriteBatch _spriteBatch, Texture2D tex)
    {
        Vector2 position = EvaluateAt(curve_curpos);
        float num = 0f;
        Vector2 vector = EvaluateTangentAt(curve_curpos);
        num = MathF.Atan2(vector.Y, vector.X);
        num += MathHelper.ToRadians(90f);

        _spriteBatch.Draw(tex, position, null, Color.White, num, new Vector2(tex.Width / 2, tex.Height / 2), new Vector2(1f, 1f), SpriteEffects.None, 0f);

    }
}