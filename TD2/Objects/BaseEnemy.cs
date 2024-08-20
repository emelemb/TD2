using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;
using TD2.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using static TD2.Utilities.Globals;
using System.Net.Http;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TD2.Objects
{
    abstract class BaseEnemy : GameObject
    {
        protected int lives;
        private bool slowed;
        protected int dmg;
        protected bool alive;
        protected float startSpeed;
        protected bool perish = false;
        public float StartSpeed { get { return startSpeed; } }
        public bool Alive { get { return alive; } set { alive = value; } }

        public bool Perish { get { return perish; } set { perish = value; } }

        public int Dmg { get { return dmg; } set { dmg = value; } }

        float posX;
        float posY;
        private float timeSlowed = 0;
        bool beenHit;


        protected Vector2 speed = new Vector2 (10, 0);
        protected Vector2 spawnPosition;
        protected CatmullRomPath cpath_moving;

        private float curve_curpos = 0;
        protected float curve_speed;
        GraphicsDevice gd;

        public float Speed { get { return curve_speed; } set { curve_speed = value; } }
        public int Lives { get { return lives; } set {  lives = value; } }

        public float Curve_curpos { get => curve_curpos; set => curve_curpos = value; }
        public float TimeSlowed { get => timeSlowed; set => timeSlowed = value; }
        public bool BeenHit { get => beenHit; set => beenHit = value; }
        public bool Slowed { get => slowed; set => slowed = value; }

        public BaseEnemy(GraphicsDevice gd)
        {
           texture = TextureManager.screwDriver;
            this.gd = gd;
            float tension_carpath = 0f; // 0 = sharp turns, 0.5 = moderate turns, 1 = soft turns
            cpath_moving = new CatmullRomPath(gd, tension_carpath);
            cpath_moving.Clear();

            LoadPath.LoadPathFromFile(cpath_moving, "Fuckthecurve.txt");

            cpath_moving.DrawFillSetup(gd, 2, 1, 256);
        }

        public void update(GameTime gameTime)
        {
               if(!perish)
            {
                Vector2 vector2 = cpath_moving.EvaluateAt(Curve_curpos);
                position.X = vector2.X;
                position.Y = vector2.Y;
                hitBox.X = (int)vector2.X; 
                hitBox.Y = (int)vector2.Y;
                Curve_curpos += curve_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (lives <= 0)
            { 
              alive = false; 
               
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
