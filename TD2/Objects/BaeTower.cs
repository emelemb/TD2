using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TD2.Managers;
using  TD2.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;
using static TD2.Utilities.Globals;
using System.IO;
using System.Data.SqlTypes;

namespace TD2.Objects
{
    abstract class BaeTower : GameObject
    {
        protected int dmg;
        protected int cost;

        int slowedTime = 3;
        float slowedfor = 0;
        public Point frameSize = new Point(68,75);
        public Point currentFrame = new Point(0, 0);
        public int timeSinceLastFrame = 0;
        public int msPerFrame = 300;
        public Point walkingSheet = new Point(4, 1);


        public int Dmg { get { return dmg; } set { dmg = value; } }
        public int Cost { get { return cost; } }

        public Texture2D PlaceTex { get => placeTex; set => placeTex = value; }

        protected float speedReduction;
        protected int delay;
        protected int timeSinceLast = 0;
        public bool active;
        public bool towerIsPLaced;
        protected List<Projectile> projectiles = new List<Projectile>();

        Texture2D placeTex;

        public BaeTower(Texture2D tex, Vector2 pos) 
        {  
            texture = tex;
            towerIsPLaced = false; // Store position independently
            active = false;           
        }

        public void collision(Projectile projectile, List<BaseEnemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (projectile.HitBox.Intersects(enemies[i].HitBox))
                {
                    if (enemies[i].Alive)
                    {
                        enemies[i].Lives = enemies[i].Lives - dmg;
                        if(!enemies[i].Slowed)
                        {
                            enemies[i].Slowed = true;
                            enemies[i].Speed = enemies[i].Speed * speedReduction;
                        }
                        projectiles.Remove(projectile);

                    }
                }
            }
        }

        public void checkProjectileRange()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].OutOfRange)
                    projectiles.Remove(projectiles[i]);                  
            }
        }



        public abstract void UpgradeTower();
        public abstract void AddProjectile(Vector2 position);

        public void update(GameTime gameTime, List<BaseEnemy> enemies)
        {
            timeSinceLast += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLast >= delay)
            {
                if (enemies.Count > 0) { AddProjectile(position); }
            
                timeSinceLast = 0;
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile projectile = projectiles[i];
                projectile.Update(gameTime);    
                collision(projectile, enemies);
            }

            checkProjectileRange();

            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Slowed)
                {
                    slowedfor += gameTime.ElapsedGameTime.Milliseconds *0.001f;
                    if(slowedfor >= slowedTime)
                    {
                        enemies[i].Slowed = false;
                        enemies[i].Speed /= speedReduction;
                        slowedfor = 0;
                    }
                }
            }
             


            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame >= msPerFrame)
            {
                timeSinceLastFrame -= msPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= walkingSheet.X)
                {
                    currentFrame.X = 0;
                }

            }
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if (active)
            {
                //sb.Draw(texture, position, Color.White);
                //    sb.Draw(texture, position, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

                foreach (Projectile projectile in projectiles)
                {
                    projectile.Draw(sb);
                }
            }
        }
    }


   
}




