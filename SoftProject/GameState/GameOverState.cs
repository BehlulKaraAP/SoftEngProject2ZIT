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
    public class GameOverState : IGameState
    {
        public void Draw(SpriteBatch spriteBatch, Game1 game)
        {
            spriteBatch.Draw(game.gameOverTexture, Vector2.Zero, Color.White);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                game.player.Health = game.player.MaxHealth;
                game.levelManager.LoadLevel(1, game.player);
                game.player.Level = game.levelManager.currentLevel;
                game.ChangeState(new PlayingState());
            }
        }
    }
}
