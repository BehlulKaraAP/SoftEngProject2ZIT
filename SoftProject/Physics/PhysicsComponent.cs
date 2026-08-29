using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Physics
{
    public class PhysicsComponent
    {
        public Vector2 Velocity;
        public float Gravity = 0.5f;
        public float JumpForce = -10f;
        public bool IsGrounded = false;

        public void ApplyPhysics(ref Vector2 position)
        {
            if (!IsGrounded)
            {
                Velocity.Y += Gravity;
            }

            position += Velocity;

            if (position.Y >= 370)
            {
                position.Y = 370;
                Velocity.Y = 0;
                IsGrounded = true;
            }
            else
            {
                IsGrounded = false;
            }
        }
    }
}
