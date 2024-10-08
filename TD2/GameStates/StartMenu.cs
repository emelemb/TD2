﻿using System;
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

            startButtonPos = new Vector2(450, 400);
            startButton = new Button( startButtonPos, TextureManager.startButton);

            exitButtonPos = new Vector2(450, 540);
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
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(TextureManager.startScreen, Vector2.Zero, Color.White);

            sb.Draw(TextureManager.startButton, startButtonPos, Color.White);
            if (startButton.Hover)
            {
                sb.Draw(TextureManager.startButton, startButtonPos, Color.Gray);
            }

            sb.Draw(TextureManager.exitButton, exitButtonPos, Color.White);
            if (exitButton.Hover)
            {
                sb.Draw(TextureManager.exitButton, exitButtonPos, Color.Gray);
            }
     
            sb.End();

        }

    }
}
