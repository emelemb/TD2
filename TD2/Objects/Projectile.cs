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
        Vector2 range = new Vector2 (130,0);
        Vector2 startPos;

        public bool OutOfRange { get => outOfRange; set => outOfRange = value; }

        public Projectile(Texture2D tex, Vector2 pos) 
        {     
            position = pos;
            startPos = pos;
        }

        public void Update(GameTime gameTime)
        {
            position.X -= speed;
            hitBox.X = (int)position.X;
            rotation -= 0.1f;  

            if(startPos.X - position.X >= range.X)
            {
                outOfRange = true;
            }
        }

   

        public void Draw(SpriteBatch sb)
        {
            if (!outOfRange)
            {
                sb.Draw(texture, position, null, Color.White, rotation, new Vector2(HitBox.Width / 2, HitBox.Height / 2), 1f, SpriteEffects.None, 0);
            }
        }
    }
}
