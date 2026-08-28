using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Animation
{
    public class SpriteAnimator
    {
        private Texture2D texture;
        public Animations Animation { get; private set; }
        private float scale = 1.5f;

        public SpriteAnimator(Texture2D texture,int frameWidth, int frameHeight)
        {
            this.texture = texture;
            Animation = new Animations();

            int columns = texture.Width / frameWidth;
            int rows = texture.Height / frameHeight;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Rectangle frame = new Rectangle(
                        column * frameWidth,
                        row * frameHeight,
                        frameWidth,
                        frameHeight
                    );

                    Animation.AddFrame(new AnimationFrame(frame));

                }
            }
        }

        public void Update()
        {
            Animation.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, bool facingLeft)
        {
            Rectangle source = Animation.CurrentFrame.SourceRectangle;

            Rectangle destination = new Rectangle(
                (int)position.X,
                (int)position.Y,
                (int)(source.Width * scale),
                (int)(source.Height * scale)
            );

            SpriteEffects effects = facingLeft
            ? SpriteEffects.FlipHorizontally
            : SpriteEffects.None;


            spriteBatch.Draw(
                texture,
                destination,
                source,
                Color.White,
                0,
                Vector2.Zero,
                effects,
                0f
            );
        }
    }
}
