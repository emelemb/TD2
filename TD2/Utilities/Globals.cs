using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2.Utilities
{
    internal class Globals
    {
        public static bool Exit { get; set; } = false;

        public static Vector2 mousePos;

        public static int screenWidth = 1200;
        public static int screenHeight = 650;

       public static int money = 500;
       public static int blackcatPrice = 100;
        public static int orangecatPrice = 200;

        public static Point mousePoint;

        public static int waveCount = 0;
        public static float timeUntilNextWave = 20;

       public static int lives;

        public static bool upgradeBlackCat = false;
        public static bool upgradeOrangeCat = false;
        public static int upgradeCost = 250;
        public static bool spawnTower { get; set; } = false;

        public static bool canMove { get; set; } = false;
        public enum TowerType
        { mage, other }

        public static TowerType currentType;
    }
}
