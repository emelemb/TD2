﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace TD2.Managers
{
    public static class TextureManager
    {
        public static Texture2D startButton, exitButton, pauseButton;
        public static Texture2D backGround, placementTexture;
        public static Texture2D wrench, screwDriver, orangeWip, blackWip, border;
        public static Texture2D pathTexture;
        public static void Textures(ContentManager content)// might also need a graphicsDevice if its stops working in the near future tehee
        {
            backGround = content.Load<Texture2D>("backround");
            startButton = content.Load<Texture2D>("BlackCat");
            exitButton = content.Load<Texture2D>("bcannime");
            pauseButton = content.Load<Texture2D>("orangecatani");
            wrench = content.Load<Texture2D>("wrench");
            screwDriver = content.Load<Texture2D>("screwdriver");
            orangeWip = content.Load<Texture2D>("orangeWip");
            blackWip = content.Load<Texture2D>("blackWip");
            border = content.Load<Texture2D>("border");
            placementTexture = content.Load<Texture2D>("BlackCat");

            //screwDriver= content.Load<Texture2D>("ScrewDriver");

            // playerTex = content.Load<Texture2D>("lmao"); finns inte endast för att komma ihåg hur mna gör lmao

            // FYI DU HAR INTE CARPATH1 DU HAR SplineCurve
        }


    }
}