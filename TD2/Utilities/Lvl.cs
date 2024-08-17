using TD2.Managers;
using TD2.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TD2
{
    internal class Lvl
    {
        /// Catmull-Rom path
        CatmullRomPath cpath_road;
        public static int levelNr;

        // Current location along the curve (car).
        // 0 and 1 is at the first and last control point, respectively.
        // How fast to go along the curve = fraction of curve / second
        float curve_speed = 0.2f;

        GraphicsDevice gd;

        public Lvl(GraphicsDevice gd)
        {
            levelNr += 1;
            this.gd = gd;
            float tension_road = 0f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            cpath_road = new CatmullRomPath(gd, tension_road);

            cpath_road.Clear();
            //            LoadPathFromFile(cpath_road, "spiral.txt");
            LoadPath.LoadPathFromFile(cpath_road, "Fuckthecurve.txt");

            // DrawFillSetup must be called (once) for every path that uses DrawFill
            // Call again if curve is altered or if window is resized
            cpath_road.DrawFillSetup(gd, 30, 2, 26);
        }
 
        public void Draw(SpriteBatch _spriteBatch)
        {
            // Draw filled paths
            cpath_road.DrawFill(gd, TextureManager.pathTexture);
            //cpath_moving.DrawFill(gd, TextureManager.wrench);

            // Draw control points
            //cpath_road.DrawPoints(_spriteBatch, Color.Black, 6);
            //cpath_moving.DrawPoints(_spriteBatch, Color.Blue, 6);

          
        }



    }
}
