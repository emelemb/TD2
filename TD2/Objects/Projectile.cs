using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;

namespace TD2.Objects
{
    internal class Projectile : GameObject
    {      
        protected float speed;
        float rotation = 0f;

        public Projectile(Texture2D tex, Vector2 pos) 
        {     
            position = pos;
        }

        public void Update(GameTime gameTime)
        {
            position.X -= speed;
            hitBox.X = (int)position.X;
            rotation -= 0.1f;  

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position,null,Color.White, rotation, new Vector2(HitBox.Width / 2,HitBox.Height /2), 1f, SpriteEffects.None, 0);
        }
    }
}
