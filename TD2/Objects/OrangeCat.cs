using TD2.Managers;
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
    internal class OrangeCat : BaeTower
    {
        public OrangeCat(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            delay = 2000;
            position = pos;
            dmg = 2;
            cost = 200;
            speedReduction = 0.5f;
     
        }

        public override void UpgradeTower()
        {
            dmg += 1;
        }

        public override void AddProjectile(Vector2 pos)
        {
            ScrewDriver screwDriver = new ScrewDriver(TextureManager.wrench, pos);
            projectiles.Add(screwDriver);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureManager.orangeCA, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(sb);
        }
    }
    }
