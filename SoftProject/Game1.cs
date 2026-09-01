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

        private EnemyFactory enemyFactory;
        private List<Enemy> enemies;

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
            

            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
