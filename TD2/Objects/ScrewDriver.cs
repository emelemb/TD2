using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;

namespace TD2.Objects
{
    internal class ScrewDriver : Projectile
    {
        public ScrewDriver(Texture2D tex, Vector2 pos, int targetDirection) : base(tex, pos, targetDirection)
        {
            speed = 3;
            texture = TextureManager.screwDriver;
            
        }
    }
}
