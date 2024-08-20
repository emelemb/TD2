using TD2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Utilities;
using SharpDX.DirectWrite;
using System.Threading;
using System.Diagnostics;

namespace TD2.Objects
{
    internal class BlackCat : BaseTower
    {
        public BlackCat(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            delay = 800;
            cost = 100;
            Position = pos;
            dmg = 1;
            speedReduction = 1.0f;
        }


        public override void AddProjectile(Vector2 position, int targetDirection)
        {
            Vector2 projectilPos = new Vector2(position.X + texture.Width/2 , position.Y + texture.Height/2);
            Wrench wrench = new Wrench(TextureManager.wrench,projectilPos, targetDirection);
            projectiles.Add(wrench); 
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureManager.BlackCA, Position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(sb);
        }
    }
} 
