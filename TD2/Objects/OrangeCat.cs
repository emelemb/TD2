﻿using TD2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Utilities;

namespace TD2.Objects
{
    internal class OrangeCat : BaseTower
    {
        public OrangeCat(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            delay = 2000;
            Position = pos;
            dmg = 2;
            cost = 200;
            speedReduction = 0.5f;
     
        }

        public override void AddProjectile(Vector2 pos, int targetDirection)
        {
            Vector2 projectilPos = new Vector2(Position.X + texture.Width / 2, Position.Y + texture.Height / 2);
            ScrewDriver screwDriver = new ScrewDriver(TextureManager.wrench, projectilPos, targetDirection);
            projectiles.Add(screwDriver);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureManager.orangeCA, Position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(sb);
        }
    }
    }
