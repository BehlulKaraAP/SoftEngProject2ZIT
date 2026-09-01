using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SoftProject.Levels
{
    public class LevelManager
    {
        public Level currentLevel { get; set; }
        public int CurrentLevelIndex { get; private set; } = 1;

        private ContentManager content;
        private GraphicsDevice graphics;

        public LevelManager(ContentManager content, GraphicsDevice graphics)
        {
            this.content = content;
            this.graphics = graphics;
        }

        public void LoadLevel(int levelNumber, Player player)
        {
            CurrentLevelIndex = levelNumber;
            if (levelNumber == 1)
            {
                currentLevel = new Level("Maps/Level1.tmx", "main_lev_buildA", content, graphics);
                player.position = new Vector2(32, 272);
                currentLevel.PortalZone = new Rectangle(784, 304, 16, 64);
            }
            else if (levelNumber == 2)
            {
                currentLevel = new Level("Maps/Level2.tmx", "main_lev_buildA", content, graphics);
                player.position = new Vector2(32, 80);
            }
        }
    }
}
