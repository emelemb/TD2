using TD2.Managers;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using TD2.Utilities;

namespace TD2.Objects
{
    internal class WIPTower : GameObject
    {
        public WIPTower(Texture2D tex, Vector2 pos) 
        {
            
        }

        public void Draw(SpriteBatch sb)
        {
            if (Globals.canMove && Globals.currentType == Globals.TowerType.mage)
            {
                sb.Draw(TextureManager.blackWip, Globals.mousePos, Color.White);

            }
            if (Globals.canMove && Globals.currentType == Globals.TowerType.other)
            {
                sb.Draw(TextureManager.orangeWip, Globals.mousePos, Color.White);

            }
        }
    }
}
