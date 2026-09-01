using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.GameState
{
    public interface IGameState
    {
        void Update(GameTime gameTime, Game1 game);
        void Draw(SpriteBatch spriteBatch, Game1 game);
    }
}
