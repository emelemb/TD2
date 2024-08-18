using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TD2.Objects;
using SharpDX.MediaFoundation;
using System.Diagnostics;
using TD2.Utilities;

namespace TD2.Objects
{
    internal class ComputerScraps : BaseEnemy
    {

        public ComputerScraps(GraphicsDevice gd) : base(gd)
        {
            startSpeed = 0.03f;
            curve_speed = startSpeed;
            Lives = 1 * Globals.waveCount;
            alive = true;
            dmg = 2;
            Slowed = false;
        }

        public override void Draw(SpriteBatch sb)
        {
            float posX = position.X;
            Debug.WriteLine(this.hitBox);

            if (!perish)
            {
                if (alive)
                {
                    cpath_moving.DrawMovingObject(Curve_curpos, sb, TextureManager.cpsParts);

                    for (int i = 0; i < lives; i++)
                    {
                        sb.Draw(TextureManager.hp, new Vector2(posX+20, position.Y), Color.White);
                        posX += TextureManager.hp.Width;
                    }
                }
                if (!alive)
                {
                    cpath_moving.DrawMovingObject(Curve_curpos, sb, TextureManager.cpsDone);
                }
            }       
        }
    }
}
