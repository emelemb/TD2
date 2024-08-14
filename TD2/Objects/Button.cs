using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Objects;
using SharpDX.MediaFoundation;

namespace TD2.Objects
{
    internal class Button : GameObject
    {

        bool hover;

        public bool Hover
        {
            get { return hover; }
            set { hover = value; }
        }

        public Button(  Vector2 pos, Texture2D tex) 
        {     
            this.position = pos;
            this.texture = tex;
        }
        public override void Draw(SpriteBatch sb)
        {
        }
    }
}

