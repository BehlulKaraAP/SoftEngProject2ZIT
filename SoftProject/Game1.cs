using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftProject.Enemies;
using SoftProject.Input;
using SoftProject.Levels;
using System.Collections.Generic;

namespace SoftProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;
        private Texture2D heartTexture;
        private EnemyFactory enemyFactory;
        private List<Enemy> enemies;

        private LevelManager levelManager;
        private Texture2D gameOverTexture;
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
            heartTexture = Content.Load<Texture2D>("heart");
            gameOverTexture = Content.Load<Texture2D>("GameOverScreen");

            enemyFactory = new EnemyFactory(Content, GraphicsDevice);
            enemies = new List<Enemy>();

            levelManager = new LevelManager(this.Content, GraphicsDevice, enemyFactory, enemies);
            levelManager.LoadLevel(1, player);
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

            if (player.Health <= 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    // Reset player health
                    player.Health = player.MaxHealth;

                    // Reload Level 1 and reset enemies via the LevelManager
                    levelManager.LoadLevel(1, player);
                    player.Level = levelManager.currentLevel;
                }

                return; // FREEZES THE GAME: Skips updating player, enemies, and portals!
            }

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                if (player.Physics.CollisionBox.Intersects(levelManager.currentLevel.PortalZone))
                {
                    levelManager.LoadLevel(levelManager.CurrentLevelIndex + 1, player);
                    player.Level = levelManager.currentLevel;
                }
            }

            player.Update(gameTime);
            levelManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            levelManager.Draw(_spriteBatch);
            player.Draw(_spriteBatch);


            for (int i = 0; i < player.Health; i++)
            {
                _spriteBatch.Draw(heartTexture, new Vector2(20 + (i * 40), 20), Color.White);
            }

            if (player.Health <= 0)
            {
                _spriteBatch.Draw(gameOverTexture, new Vector2(0, 0), Color.White);
            }
            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
