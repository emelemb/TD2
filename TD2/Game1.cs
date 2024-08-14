using TD2.Managers;
using TD2.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace TD2
{
    public class Game1 : Game
    {
        public static GameStateManager gameStateManager;
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        ParticleSystem particleSystem;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.ApplyChanges();


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameStateManager = new GameStateManager(GraphicsDevice);

            TextureManager.Textures(Content);
            gameStateManager.LoadContent(Content);

            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("OrangeCat"));
            textures.Add(Content.Load<Texture2D>("BlackCat"));
            textures.Add(Content.Load<Texture2D>("diamond"));
            particleSystem = new ParticleSystem(textures, new Vector2(400, 240));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Globals.Exit)
                Exit();

            gameStateManager.Update(gameTime);

            particleSystem.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleSystem.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

          
            gameStateManager.Draw(_spriteBatch);
            particleSystem.Draw(_spriteBatch);
            // TODO: Add your drawing code here



            base.Draw(gameTime);

        }
    }
}
