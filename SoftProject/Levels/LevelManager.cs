using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Levels
{
    public class LevelManager
    {
        public Level currentLevel { get; set; }

        private ContentManager content;
        private GraphicsDevice graphics;

        public LevelManager(ContentManager content, GraphicsDevice graphics)
        {
            this.content = content;
            this.graphics = graphics;
        }

        public void LoadLevel(int levelNumber)
        {
            if (levelNumber == 1)
            {
                currentLevel = new Level("Maps/Level1.tmx", "main_lev_buildA", content, graphics);
            }
        }
    }
}
