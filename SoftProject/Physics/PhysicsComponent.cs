using Microsoft.Xna.Framework;
using SharpDX.DirectWrite;
using System.Collections.Generic;

namespace SoftProject.Physics
{
    public class PhysicsComponent
    {
        public Vector2 Velocity;
        public float Gravity = 0.5f;
        public float JumpForce = -10f;
        public bool IsGrounded = false;

        private int hitboxWidth;
        private int hitboxHeight;
        private int offsetX;
        private int offsetY;


        public Rectangle CollisionBox { get; private set; }

        public PhysicsComponent(int width, int height, int offsetX, int offsetY)
        {
            this.hitboxWidth = width;
            this.hitboxHeight = height;
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }
        public void ApplyPhysics(ref Vector2 position, List<Rectangle> collisionRectangles)
        {
            Velocity.Y += Gravity;

            position.X += Velocity.X;
            UpdateCollisionBox(position);

            foreach (Rectangle rectangle in collisionRectangles)
            {
                if (CollisionBox.Intersects(rectangle))
                {
                    if (Velocity.X > 0) 
                    {
                        position.X = rectangle.Left - hitboxWidth - offsetX;
                    }
                    else if (Velocity.X < 0) 
                    {
                        position.X = rectangle.Right - offsetX;
                    }

                    Velocity.X = 0; 
                    UpdateCollisionBox(position);
                }
            }

            position.Y += Velocity.Y;
            UpdateCollisionBox(position);

            IsGrounded = false;

            foreach (Rectangle rectangle in collisionRectangles)
            {
                if (CollisionBox.Intersects(rectangle))
                {
                    if (Velocity.Y > 0) 
                    {
                        position.Y = rectangle.Top - hitboxHeight - offsetY;
                        IsGrounded = true;
                    }
                    else if (Velocity.Y < 0) 
                    {
                        position.Y = rectangle.Bottom - offsetY; 
                    }

                    Velocity.Y = 0; 
                    UpdateCollisionBox(position);
                }
            }

        }

        private void UpdateCollisionBox(Vector2 position)
        {
            CollisionBox = new Rectangle(
                (int)position.X + offsetX,
                (int)position.Y + offsetY,
                hitboxWidth,
                hitboxHeight
            );
        }
    }
}
