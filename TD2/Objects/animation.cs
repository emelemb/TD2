using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;

namespace TD2.Objects
{
    internal class animation
    {
        public Point frameSize = new Point(1000, 700);
        public Point currentFrame = new Point(0, 0);
        public int timeSinceLastFrame = 0;
        public int msPerFrame = 800;
        public Point walkingSheet = new Point(2, 1);

       public animation() { }

        public void update(GameTime gametime)
        {
            timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame >= msPerFrame)
            {
                timeSinceLastFrame -= msPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= walkingSheet.X)
                {
                    currentFrame.X = 0;
                }

            }
            timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.conveyerAnime, Vector2.Zero, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
