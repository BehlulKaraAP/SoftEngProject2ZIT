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
        private Enemy testEnemy;

        private EnemyFactory enemyFactory;
        private List<Enemy> enemies = new List<Enemy>();

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
            levelManager.LoadLevel(1, player);
            player.Level = levelManager.currentLevel;

            enemyFactory = new EnemyFactory(Content, GraphicsDevice);
            enemies.Add(enemyFactory.CreateSkeleton(player, levelManager.currentLevel, new Vector2(200,50)));
            enemies.Add(enemyFactory.CreateSkeletonWithShield(player, levelManager.currentLevel, new Vector2(80, 50)));
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

                    enemies.Clear();

                }
            }

            player.Update(gameTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            levelManager.currentLevel?.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
