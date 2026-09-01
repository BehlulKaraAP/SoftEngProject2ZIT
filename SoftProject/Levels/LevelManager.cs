using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoftProject.Enemies;
using System.Collections.Generic;

namespace SoftProject.Levels
{
    public class LevelManager
    {
        public Level currentLevel { get; set; }
        public int CurrentLevelIndex { get; private set; } = 1;

        private ContentManager content;
        private GraphicsDevice graphics;
        private EnemyFactory enemyFactory;
        private List<Enemy> enemiesList;
        public List<Enemy> ActiveEnemies => enemiesList;

        public LevelManager(ContentManager content, GraphicsDevice graphics, EnemyFactory factory, List<Enemy> enemies)
        {
            this.content = content;
            this.graphics = graphics;
            this.enemyFactory = factory;
            this.enemiesList = enemies;
        }

        public void LoadLevel(int levelNumber, Player player)
        {
            CurrentLevelIndex = levelNumber;
            enemiesList.Clear();

            if (levelNumber == 1)
            {
                currentLevel = new Level("Maps/Level1.tmx", "main_lev_buildA", content, graphics);
                player.position = new Vector2(32, 272);
                currentLevel.PortalZone = new Rectangle(784, 304, 16, 64);

                enemiesList.Add(enemyFactory.CreateSkeleton(player, currentLevel, new Vector2(200, 50)));
                enemiesList.Add(enemyFactory.CreateSkeletonWithShield(player, currentLevel, new Vector2(80, 50)));
            }
            else if (levelNumber == 2)
            {
                currentLevel = new Level("Maps/Level2.tmx", "main_lev_buildA", content, graphics);
                player.position = new Vector2(32, 80);

                enemiesList.Add(enemyFactory.CreateSkeletonWithSpear(player, currentLevel, new Vector2(304, 208)));
                enemiesList.Add(enemyFactory.CreateSkeleton(player, currentLevel, new Vector2(200, 400)));
                enemiesList.Add(enemyFactory.CreateSkeletonArcher(player, currentLevel, new Vector2(250, 400)));
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = enemiesList.Count - 1; i >= 0; i--)
            {
                enemiesList[i].Update(gameTime);
                if (enemiesList[i].IsDead)
                {
                    enemiesList.RemoveAt(i);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
            foreach (Enemy enemy in enemiesList)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
