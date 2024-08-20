using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TD2.Objects
{
    abstract class GameObject
    {
      
        protected Rectangle hitBox;
        protected Vector2 objectCenter;
        protected Vector2 position;
        protected Texture2D texture;
        public Vector2 Position { get => position; set => position = value; }



        public Texture2D Texture { get { return texture; } }

        public Rectangle HitBox
        {
            get
            {
                hitBox.Y = (int)Position.Y;
                hitBox.X = (int)Position.X;
                hitBox.Width = (int)texture.Width;
                hitBox.Height = (int)texture.Height;
                return hitBox;
            }
        }

        public Vector2 ObjectCenter
        {
            get
            {
                objectCenter.Y = (int)texture.Height / 2;
                objectCenter.X = (int)texture.Width / 2;
                return objectCenter;
            }
        }

    }
}
