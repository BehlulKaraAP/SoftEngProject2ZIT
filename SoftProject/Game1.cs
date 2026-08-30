using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftProject.Input;
using SoftProject.Levels;
using System;
using System.Collections.Generic;
using TiledCS;

namespace SoftProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;

        private LevelManager levelManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObject();
            // TODO: use this.Content to load your game content here

            levelManager = new LevelManager(this.Content, GraphicsDevice);
            levelManager.LoadLevel(1);
            player.Level = levelManager.currentLevel;


        }



        private void InitializeGameObject()
        {
            player = new Player(new KeyboardReader(), GraphicsDevice);
            player.LoadContent(this.Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            levelManager.currentLevel?.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
