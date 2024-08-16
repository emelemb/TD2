using System;
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
        public static Texture2D startButton, exitButton, pauseButton, playButton;
        public static Texture2D backGround, placementTexture;
        public static Texture2D wrench, screwDriver, orangeWip, blackWip, border, orangeCA, BlackCA;
        public static Texture2D pathTexture, convyerPos, conveyerNeg;
        public static Texture2D cpsParts, cpsDone, tbsParts, tbsDone, hp;
        public static void Textures(ContentManager content)// might also need a graphicsDevice if its stops working in the near future tehee
        {
            backGround = content.Load<Texture2D>("bgbg");
            startButton = content.Load<Texture2D>("startButton");
            exitButton = content.Load<Texture2D>("QuitButton");
            pauseButton = content.Load<Texture2D>("pauseButton");
            playButton = content.Load<Texture2D>("playButton");

            orangeCA = content.Load<Texture2D>("orangecatani");
             BlackCA = content.Load<Texture2D>("bcannime");
            wrench = content.Load<Texture2D>("wrench");
            screwDriver = content.Load<Texture2D>("screwdriver");
            orangeWip = content.Load<Texture2D>("orangeWip");
            blackWip = content.Load<Texture2D>("blackWip");

            cpsParts = content.Load<Texture2D>("compterNot");
            cpsDone = content.Load<Texture2D>("computerDone");
            tbsParts = content.Load<Texture2D>("tabletNot");
            tbsDone = content.Load<Texture2D>("TabletDone");
            hp = content.Load<Texture2D>("hp");


            pathTexture = content.Load<Texture2D>("pauseButton");

            convyerPos = content.Load<Texture2D>("conEndNeg");
            conveyerNeg = content.Load<Texture2D>("conEndPos");

            border = content.Load<Texture2D>("bg");
            placementTexture = content.Load<Texture2D>("BlackCat");

            //screwDriver= content.Load<Texture2D>("ScrewDriver");

            // playerTex = content.Load<Texture2D>("lmao"); finns inte endast för att komma ihåg hur mna gör lmao

            // FYI DU HAR INTE CARPATH1 DU HAR SplineCurve
        }


    }
}