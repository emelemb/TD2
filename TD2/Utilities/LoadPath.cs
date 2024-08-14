using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TD2;

namespace TD2
{
    internal static class LoadPath
    {
        public static void LoadPathFromFile(CatmullRomPath path, string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
                path.AddPoint(InputParser.parse_Vector2(line));
        }

        //Hoppas över i genomgång.

    }
}