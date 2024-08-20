using TD2.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Utilities;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.Configuration;

namespace TD2.Objects
{
    internal class EndOfConveyerBelt : GameObject
    {
        bool alive = true;
        int lives = 10;
        bool positive;

        public int Lives { get { return lives; } }
        public EndOfConveyerBelt(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.Position = position;
        }

        public void Update(GameTime gametime)
        {
            Globals.lives = lives;

        }

        public void collision( List<BaseEnemy> enemies)
        {
         
            for (int i = 0; i < enemies.Count; i++)
            {    
                if (HitBox.Intersects(enemies[i].HitBox))
                 {         
                    if (!enemies[i].Perish)
                    {
                        if (enemies[i].Alive)
                        {
                            lives = lives - enemies[i].Dmg;
                        }
                        if (!enemies[i].Alive)
                        {
                            Globals.money += 50;
                        }
                    }

                    enemies[i].Perish = true;
                    enemies.Remove(enemies[i]); 
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {    
         sb.Draw(TextureManager.conveyerNeg,HitBox, Color.White);
        }

    }
}
