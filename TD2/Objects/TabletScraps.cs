using Microsoft.VisualBasic.Logging;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;
using Microsoft.Xna.Framework;
using TD2.Utilities;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;

namespace TD2.Objects
{
    internal class TabletScraps : BaseEnemy
    {
        
        public TabletScraps(GraphicsDevice gd) : base(gd)
        {
            startSpeed = 0.05f;
            curve_speed = startSpeed;
            Lives = 2 * Globals.waveCount;
            dmg = 1;
            alive = true;
            Slowed = false;
            
        }

        public override void Draw(SpriteBatch sb)
        {
            float posX = position.X;

            if (!perish)
            {
                if (alive)
                {
                    cpath_moving.DrawMovingObject(Curve_curpos, sb, TextureManager.tbsParts);

                    for (int i = 0; i < lives; i++) 
                    { 
                       sb.Draw(TextureManager.hp, new Vector2(posX, position.Y + 30), Color.White);
                        posX += TextureManager.hp.Width;

                    }
                }
                if (!alive)
                {
                    cpath_moving.DrawMovingObject(Curve_curpos, sb, TextureManager.tbsDone);
                }
            }
          

            // Other drawing logic...
        }
    }
}
