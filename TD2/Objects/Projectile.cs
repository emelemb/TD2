using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;

namespace TD2.Objects
{
    internal class Projectile : GameObject
    {
        protected float speed;
        float rotation = 0f;
        bool outOfRange = false;
        Vector2 range = new Vector2(130, 0);
        bool changedir = false;
        Vector2 startPos;
        int targetDir;


        public bool OutOfRange { get => outOfRange; set => outOfRange = value; }

        public Projectile(Texture2D tex, Vector2 pos, int targetDirection)
        {
            position = pos;
            startPos = pos;
            targetDir = targetDirection;
        }

        public void Update(GameTime gameTime)
        {
            position.X += (speed * targetDir);
            hitBox.X = (int)Position.X;
            rotation -= 0.1f;
            //changedir = true;
            if (targetDir < 0)
            {
                if (startPos.X - Position.X >= range.X)
                {
                    outOfRange = true;
                }
            }
            if (targetDir > 0)
            {
                if (Position.X - startPos.X >= range.X)
                {
                    outOfRange = true;

                }

            }
        }

            public void Draw(SpriteBatch sb)
            {
                if (!outOfRange)
                {
                    sb.Draw(texture, Position, null, Color.White, rotation, new Vector2(HitBox.Width / 2, HitBox.Height / 2), 1f, SpriteEffects.None, 0);
                }
            }
        }
    } 
