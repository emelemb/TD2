using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD2.Utilities;
using TD2.Objects;
using TD2.Managers;
using static TD2.Utilities.Globals;
using static TD2.Managers.GameStateManager;
using System.Collections;
using Microsoft.VisualBasic.ApplicationServices;


//using TowerDefence.Handlers;       what , this shuld not exist 

namespace TD2.GameStates
{
    internal class GamePlay
    {
        StartMenu startMenu;
        Button pauseButton;
        Button resumeButton;
        Button exitToMainMenuButton;
        Lvl lvl;
        WIPTower wipTower;
        public GraphicsDevice graphicsDevice;

        RenderTarget2D renderTarget;

        UI UI;
        TowerManager towerManager;
        EnemyManager enemyManager;
        Vector2 endPosition;
        EndOfConveyerBelt belt;

        BaeTower tower;
        TowerMenu towerMenu;
        Vector2 exitToMainMenuButtonPos;
        Vector2 resumeButtonPos;
        Vector2 pauseButtonPos;

      
        public GamePlay(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            enemyManager = new EnemyManager(graphicsDevice);
            towerManager = new TowerManager(enemyManager, this);
            lvl = new Lvl(graphicsDevice);
            renderTarget = new RenderTarget2D(graphicsDevice, screenWidth, screenHeight);
            wipTower = new WIPTower(TextureManager.startButton, Globals.mousePos);
            UI = new UI();
        }
        internal enum PlayStates
        {
            play,
            pause
        }

        bool waveActive()
        {
            if (enemyManager.enemies.Count > 0)
            {
                return true;
            }
            return false;
        }

        internal static PlayStates playState;

        public void LoadContent(ContentManager content)
        {
            towerManager.LoadContent(content);      
            UI.LoadContent(content);    
            //carManager = new CarManager(Game1._graphics.GraphicsDevice);
            //policeManager = new PoliceManager();
            //policeManager.AddPolice(new Vector2(400, 100));

            pauseButtonPos = new Vector2(690, 20);
            pauseButton = new Button(pauseButtonPos, TextureManager.pauseButton);

            resumeButtonPos = new Vector2(300, 200);
            resumeButton= new Button(resumeButtonPos, TextureManager.playButton);

            exitToMainMenuButtonPos = new Vector2(100, 200);
            exitToMainMenuButton = new Button(exitToMainMenuButtonPos, TextureManager.exitButton);

            endPosition = new Vector2(900,600 );
            belt = new EndOfConveyerBelt(TextureManager.conveyerNeg, endPosition);
          
            towerMenu = new TowerMenu();
        }

        public bool CanPlace(BaeTower tower)
        {
            if (waveActive()) { return false; }
            if(tower.HitBox.Intersects(UI.Bounds))
            {
                return false;
            }
            Color[] pixels = new Color[tower.HitBox.Width* tower.HitBox.Height];
            Color[] pixels2 = new Color[tower.HitBox.Width * tower.HitBox.Height];
            tower.Texture.GetData<Color>(pixels2);
            renderTarget.GetData(0, tower.HitBox, pixels, 0, pixels.Length);
            for (int i = 0; i < pixels.Length; ++i)
            {
                if (pixels[i].A > 0.0f && pixels2[i].A > 0.0f)
                    return false;
            }
            return true;
        }

        public void GetMousePos()
        {
            MouseState mouseMovement = Mouse.GetState();
            mousePos.X = mouseMovement.X;
            mousePos.Y = mouseMovement.Y;
            mousePoint = new Point((int)mousePos.X, (int)mousePos.Y);
        }

        public void ButtonsLogic()
        {
            if (pauseButton.HitBox.Contains(mousePoint))
            {
                pauseButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && pauseButton.HitBox.Contains(mousePoint))
                {
                    playState = PlayStates.pause;
                }
            }

            if (resumeButton.HitBox.Contains(mousePoint))
            {
                resumeButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && resumeButton.HitBox.Contains(mousePoint))
                {
                    playState = PlayStates.play;
                }

            }
            if (exitToMainMenuButton.HitBox.Contains(mousePoint))
            {
                exitToMainMenuButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && exitToMainMenuButton.HitBox.Contains(mousePoint))
                {
                    state = GameStateManager.GameStates.StartMenu;
                    playState = PlayStates.play;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            GetMousePos();

            switch (playState)
            {
                case PlayStates.play:

                    //tower.Show();
                    towerMenu.Show();
                    towerManager.Update(gameTime, enemyManager.enemies);
                    enemyManager.Update(gameTime);
                    belt.collision(enemyManager.enemies);
                    belt.Update(gameTime);
                    UI.Update(gameTime );
                    ButtonsLogic();
                   
                    

                    if (belt.Lives <= 0)
                    {
                        state = GameStateManager.GameStates.EndScreen;
                    }

                    if(Globals.waveCount >= 10)
                    {
                        state = GameStateManager.GameStates.EndScreen;
                    }

                    break;

                case PlayStates.pause:

                    ButtonsLogic();
                    break;

            }       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
          
            switch (playState)
            { 
                case PlayStates.play:
                    drawOnRendertarget(spriteBatch);
                    spriteBatch.Begin();
                    //BaseEnemy.Draw(spriteBatch);
                    spriteBatch.Draw(TextureManager.backGround, Vector2.Zero, Color.White);
                    spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
                    wipTower.Draw(spriteBatch);
                    enemyManager.Draw(spriteBatch);
                    UI.Draw(spriteBatch);
                    spriteBatch.Draw(TextureManager.pauseButton, pauseButtonPos, Color.White);
                    spriteBatch.End();
                    break;

                case PlayStates.pause:
                    spriteBatch.Begin();

                    if (pauseButton.Hover)
                    {
                        spriteBatch.Draw(TextureManager.exitButton, resumeButtonPos, Color.Gray);
                    }
                    else
                    {
                        spriteBatch.Draw(TextureManager.exitButton, resumeButtonPos, Color.White);
                    }
                        spriteBatch.Draw(TextureManager.playButton,exitToMainMenuButtonPos, Color.Purple);
                    spriteBatch.End();
                    break;
            }               
        }

        public void drawOnRendertarget(SpriteBatch spriteBatch)
        {
            graphicsDevice.SetRenderTarget(renderTarget);
            graphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            lvl.Draw(spriteBatch);
            towerManager.Draw(spriteBatch);
            belt.Draw(spriteBatch);
            spriteBatch.End();

            graphicsDevice.SetRenderTarget(null);
        }
    }
}
