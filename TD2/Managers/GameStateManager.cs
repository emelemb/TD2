using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using TD2.GameStates;
using Microsoft.Xna.Framework.Content;

namespace TD2.Managers
{
    public class GameStateManager
    {
        StartMenu StartMenu = new StartMenu();
        GamePlay GamePlay;
        EndScreen EndScreen = new EndScreen();

        public GameStateManager(GraphicsDevice graphicsDevice) 
        {
            GamePlay = new GamePlay(graphicsDevice);
        }
        
        internal enum GameStates
        {
            StartMenu,
            GamePlay,
            EndScreen
        }

        internal static GameStates state;

        internal void LoadContent(ContentManager content)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    StartMenu.LoadContent(content);
                    GamePlay.LoadContent(content);
                    EndScreen.LoadContent(content);
                    break;
            }
        }

        internal void Update(GameTime gameTime)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    StartMenu.Update(gameTime);
                    break;
                case GameStates.GamePlay:
                    GamePlay.Update(gameTime);
                    break;
                case GameStates.EndScreen:
                    EndScreen.Update(gameTime);
                    break;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case GameStates.StartMenu:
                    StartMenu.Draw(spriteBatch);
                    break;
                case GameStates.GamePlay:
                    GamePlay.Draw(spriteBatch);
                    break;
                case GameStates.EndScreen:
                    EndScreen.Draw(spriteBatch);
                    break;

            }

        }

    }
}
