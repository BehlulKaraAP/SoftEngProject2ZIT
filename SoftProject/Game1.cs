using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftProject.Enemies;
using SoftProject.GameState;
using SoftProject.Input;
using SoftProject.Levels;
using System.Collections.Generic;

namespace SoftProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Player player;
        public Texture2D heartTexture;
        private EnemyFactory enemyFactory;
        private List<Enemy> enemies;

        public LevelManager levelManager;

        public Texture2D startScreenTexture;
        public Texture2D gameOverTexture;
        public Texture2D victoryTexture;

        private IGameState currentGameState;

        public void ChangeState(IGameState newState)
        {
            currentGameState = newState;
        }



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
            startScreenTexture = Content.Load<Texture2D>("StartScreen");
            victoryTexture = Content.Load<Texture2D>("VictoryScreen");

            enemyFactory = new EnemyFactory(Content, GraphicsDevice);
            enemies = new List<Enemy>();

            levelManager = new LevelManager(this.Content, GraphicsDevice, enemyFactory, enemies);
            levelManager.LoadLevel(1, player);
            player.Level = levelManager.currentLevel;

            ChangeState(new StartScreenState());
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

            currentGameState.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            currentGameState.Draw(_spriteBatch, this);
            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
