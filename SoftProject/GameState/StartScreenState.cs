using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace SoftProject.GameState
{
    public class StartScreenState : IGameState
    {
        public void Draw(SpriteBatch spriteBatch, Game1 game)
        {
            spriteBatch.Draw(game.startScreenTexture, Vector2.Zero, Color.White);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.levelManager.LoadLevel(1, game.player);
                game.player.Level = game.levelManager.currentLevel;
                game.ChangeState(new PlayingState());
            }
        }
    }
}
