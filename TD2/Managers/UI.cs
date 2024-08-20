using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TD2.Objects;
using TD2.Utilities;
using static TD2.Utilities.Globals;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace TD2.Managers
{
    internal class UI
    {
        public SpriteFont font;
        int time;
        Rectangle bounds;
        Vector2 position;
        public Rectangle Bounds { get => bounds; set => bounds = value; }

        public UI()
        {
            position = new Vector2(900, 0);
            Bounds = new Rectangle((int)position.X, (int)position.Y, 300, 650);
        }
        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("sp");
        }

        public void Update(GameTime gameTime)
        {
            time = Convert.ToInt32(Globals.timeUntilNextWave);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureManager.border, new Vector2(0,0), Color.White);
            sb.DrawString(font, " " + Globals.waveCount, new Vector2(892, 374), Color.White);
            sb.DrawString(font," " + Globals.money, new Vector2(890, 99), Color.White);
            sb.DrawString(font, " " + time, new Vector2(885, 312), Color.White);
            sb.DrawString(font, " " + Globals.lives, new Vector2(895, 226), Color.White);
        }
    }
}
