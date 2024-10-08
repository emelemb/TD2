﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TD2.Objects;
using System.Text;
using System.Threading.Tasks;
using TD2.GameStates;
using TD2.Managers;
using Microsoft.Xna.Framework.Input;
using TD2.Utilities;

namespace TD2.GameStates
{
    internal class EndScreen
    {
        Button startButton;
        Button exitButton;
        Vector2 exitButtonPos;

        Point mousePoint;

        public void LoadContent(ContentManager content)
        {
            exitButtonPos = new Vector2(450, 520);
            exitButton = new Button(exitButtonPos, TextureManager.exitButton);
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

            if (exitButton.HitBox.Contains(mousePoint))
            {
                exitButton.Hover = true;

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && exitButton.HitBox.Contains(mousePoint))
                {
                    Globals.Exit = true;
                }
            }
            else { exitButton.Hover = false; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (Globals.lives <= 0)
            {
                spriteBatch.Draw(TextureManager.loseScreen, new Vector2(0, 0), Color.White);      
            }
            else
            {
                spriteBatch.Draw(TextureManager.winScreen, new Vector2(0, 0), Color.White);
              
            }
            if (exitButton.Hover) { spriteBatch.Draw(TextureManager.exitButton, exitButtonPos, Color.Gray); }
            else { spriteBatch.Draw(TextureManager.exitButton, exitButtonPos, Color.White); }

            spriteBatch.End();

        }
    }
}
