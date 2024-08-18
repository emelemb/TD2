using TD2.Objects;
using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using TD2.Utilities;
using System.Diagnostics;
using SharpDX.MediaFoundation;
using SharpDX.X3DAudio;
using SharpDX.XInput;
using System.Net;
using TD2.GameStates;


namespace TD2.Managers
{
    internal class TowerManager
    {

        List<BaseTower> towerList;
        public Vector2 towerPos;
        EnemyManager enemyManager;
        GamePlay gameplay;


        public void LoadContent(ContentManager content)
        {

        }
        //LaserManager laserManager;
        public TowerManager(EnemyManager enemyManager, GamePlay gameplay)
        {
            towerList = new List<BaseTower>();
            this.enemyManager = enemyManager;
            this.gameplay = gameplay;
            
        }

        //public List<BaeTower> GetAllOf()
        //{
        //    return towerList;
        //}

        public void AddTower(Vector2 pos)
        {
            BaseTower tower = null;
            switch (Globals.currentType)
            {
                case Globals.TowerType.mage:
                    BaseTower mage = new BlackCat(TextureManager.placementTexture, pos);
                    mage.active = true;
                    tower = mage;
                    if (tower != null && gameplay.CanPlace(tower))
                    { 
                      towerList.Add(tower); 
                      Globals.money -= mage.Cost;
                    }
                    break;

                case Globals.TowerType.other:
                    BaseTower other = new OrangeCat(TextureManager.placementTexture, pos);
                    other.active = true;
                    tower = other;
                    if (tower != null && gameplay.CanPlace(tower))
                    { towerList.Add(tower); 
                     Globals.money -= other.Cost;
                    }
                    break;
            }


            gameplay.drawOnRendertarget(new SpriteBatch(gameplay.graphicsDevice));

        }

        public void Update(GameTime gameTime, List<BaseEnemy> enemies)
        {

            if (Globals.spawnTower)
            {
                // When spawning a tower, keep updating its position to the mouse position
                towerPos = Globals.mousePos;
                Globals.spawnTower = false;
            }
    

            if (Globals.canMove)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    // If left-clicked, add the tower at the current mouse position
                    towerPos = Globals.mousePos;
                          Globals.canMove = false;
                    Vector2 projectilPos = new Vector2(towerPos.X+30, towerPos.Y+35);
                    AddTower(towerPos);
              
                }
            }
            foreach( BaseTower b in towerList)
            {       
                    b.update(gameTime, enemies);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseTower B in towerList)
            {
                B.Draw(spriteBatch);

            }

        










        }
    }
}
       

    

