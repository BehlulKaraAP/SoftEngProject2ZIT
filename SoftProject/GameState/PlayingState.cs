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
    public class PlayingState : IGameState
    {
        public void Draw(SpriteBatch spriteBatch, Game1 game)
        {
            game.levelManager.Draw(spriteBatch);
            game.player.Draw(spriteBatch);

            for (int i = 0; i < game.player.Health; i++)
            {
                spriteBatch.Draw(game.heartTexture, new Vector2(20 + (i * 40), 20), Color.White);
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            if (game.player.Health <= 0)
            {
                game.ChangeState(new GameOverState());
                return;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                if (game.player.Physics.CollisionBox.Intersects(game.levelManager.currentLevel.PortalZone))
                {
                    game.levelManager.LoadLevel(game.levelManager.CurrentLevelIndex + 1, game.player);
                    game.player.Level = game.levelManager.currentLevel;
                }
            }

            game.player.Update(gameTime);
            game.levelManager.Update(gameTime);
        }
    }
}
