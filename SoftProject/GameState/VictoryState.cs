using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.GameState
{
    public class VictoryState : IGameState
    {
        public void Draw(SpriteBatch spriteBatch, Game1 game)
        {
            spriteBatch.Draw(game.victoryTexture, Vector2.Zero, Color.White);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.ChangeState(new StartScreenState());
            }
        }
    }
}
