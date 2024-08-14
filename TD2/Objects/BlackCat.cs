﻿using TD2.Managers;
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
    internal class BlackCat : BaeTower
    {
        public BlackCat(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            delay = 1500;
            cost = 100;
            position = pos;
            dmg = 1;
            speedReduction = 1.01f;
        }

        public override void UpgradeTower()
        {
            dmg += 1;
        }

        public override void AddProjectile(Vector2 position)
        {
            Wrench wrench = new Wrench(TextureManager.wrench,position);
            projectiles.Add(wrench);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureManager.exitButton, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }


    }





} 
