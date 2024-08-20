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
        public static Texture2D startButton, exitButton, pauseButton, playButton, infoButton;
        public static Texture2D backGround, placementTexture;
        public static Texture2D wrench, screwDriver, orangeWip, blackWip, border, orangeCA, BlackCA;
        public static Texture2D pathTexture, convyerPos, conveyerNeg, conveyerAnime;
        public static Texture2D cpsParts, cpsDone, tbsParts, tbsDone, hp;
        public static Texture2D startScreen, pauseScreen, loseScreen, winScreen;
        public static void Textures(ContentManager content)// might also need a graphicsDevice if its stops working in the near future tehee
        {
            backGround = content.Load<Texture2D>("bgbg");
            startButton = content.Load<Texture2D>("startButton");
            exitButton = content.Load<Texture2D>("QuitButton");
            pauseButton = content.Load<Texture2D>("pauseButton");
            playButton = content.Load<Texture2D>("playButton");
            infoButton = content.Load<Texture2D>("InfoButton");

            orangeCA = content.Load<Texture2D>("orangecatani");
             BlackCA = content.Load<Texture2D>("bcannime");
            wrench = content.Load<Texture2D>("wrench");
            screwDriver = content.Load<Texture2D>("screwdriver");
            orangeWip = content.Load<Texture2D>("Wipo");
            blackWip = content.Load<Texture2D>("Wip");

            cpsParts = content.Load<Texture2D>("compterNot");
            cpsDone = content.Load<Texture2D>("computerDone");
            tbsParts = content.Load<Texture2D>("tabletNot");
            tbsDone = content.Load<Texture2D>("TabletDone");
            hp = content.Load<Texture2D>("hp");

            conveyerNeg = content.Load<Texture2D>("conEndNeg");

            pathTexture = content.Load<Texture2D>("path");
            conveyerAnime = content.Load<Texture2D>("conveyerAnime");
                                                                                                 
            border = content.Load<Texture2D>("bg");
            placementTexture = content.Load<Texture2D>("wipo");

            startScreen = content.Load<Texture2D>("startScreen");
            loseScreen = content.Load<Texture2D>("loseScreen");
            winScreen = content.Load<Texture2D>("winScreen");
            pauseScreen = content.Load<Texture2D>("pauseMeny");

        }


    }
}