using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using TD2.Managers;
using System.Net.Security;
using TD2.Objects;
using TD2.Utilities;
using static TD2.Managers.GameStateManager;



namespace TD2.GameStates
{
    internal class StartMenu
    {
        Button startButton;
        Button exitButton;
        Button infoButton;

        Vector2 startButtonPos;
        Vector2 exitButtonPos;
        Vector2 infoButtonPos;

        Point mousePoint;

        public void LoadContent(ContentManager content)
        {
            TextureManager.Textures(content);


            startButtonPos = new Vector2(450, 200);
            startButton = new Button( startButtonPos, TextureManager.startButton);

            infoButtonPos = new Vector2(430, 270);
            infoButton = new Button( infoButtonPos, TextureManager.infoButton );    

            exitButtonPos = new Vector2(450, 340);
            exitButton = new Button( exitButtonPos, TextureManager.exitButton);
        }

        public void GetMousePos()
        {
            MouseState mouseMovement = Mouse.GetState();
            Vector2 mousePos;
            mousePos.X = mouseMovement.X;
            mousePos.Y = mouseMovement.Y;
            mousePoint = new Point((int)mousePos.X, (int)mousePos.Y);
        }

        public void Update(GameTime gameTime)
        {
            GetMousePos();

            if (startButton.HitBox.Contains(mousePoint))
            {
                startButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && startButton.HitBox.Contains(mousePoint))
                {
                    state = GameStateManager.GameStates.GamePlay;
                }
            }

            if (infoButton.HitBox.Contains(mousePoint))
            {
                infoButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed &&infoButton.HitBox.Contains(mousePoint))
                {
                   // state = GameStateManager.GameStates.GamePlay;
                }
            }

            else if (exitButton.HitBox.Contains(mousePoint))
            {
                exitButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && exitButton.HitBox.Contains(mousePoint))
                {
                    Globals.Exit = true;
                }
            }
            else
            {
                startButton.Hover = false;
                exitButton.Hover = false;
                infoButton.Hover = false;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(TextureManager.backGround, Vector2.Zero, Color.White);

            sb.Draw(TextureManager.startButton, startButtonPos, Color.White);
            if (startButton.Hover)
            {
                sb.Draw(TextureManager.startButton, startButtonPos, Color.Gray);
                // rn u have to play "find the button" cause itll only show when u hover over it >:)
            }

            sb.Draw(TextureManager.infoButton, infoButtonPos, Color.White);
            if (infoButton.Hover)
            {
                sb.Draw(TextureManager.infoButton, infoButtonPos, Color.Gray);
                // rn u have to play "find the button" cause itll only show when u hover over it >:)
            }

            sb.Draw(TextureManager.exitButton, exitButtonPos, Color.White);
            if (exitButton.Hover)
            {
                sb.Draw(TextureManager.exitButton, exitButtonPos, Color.Gray);
            }
            //else
            //{
            //    sb.Draw(TextureManager.startButton, startButtonPos, Color.White);
            //    sb.Draw(TextureManager.exitButton, exitButtonPos, Color.White);

            //remove the comment thingy to not have to play "find the button"
            //}
            sb.End();


        }

    }
}
