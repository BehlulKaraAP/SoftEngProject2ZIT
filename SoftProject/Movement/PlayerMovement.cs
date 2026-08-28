using Microsoft.Xna.Framework;
using SoftProject.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Movement
{
    public class PlayerMovement
    {
    //    public Vector2 Velocity { get; private set; }
    //    public bool IsGrounded { get; private set; }

    //    private readonly float moveSpeed;
    //    private readonly float gravity;
    //    private readonly float jumpSpeed;
    //    private readonly float groundY;

    //    public PlayerMovement(float moveSpeed, float gravity, float jumpSpeed, float groundY)
    //    {
    //        this.moveSpeed = moveSpeed;
    //        this.gravity = gravity;
    //        this.jumpSpeed = jumpSpeed;
    //        this.groundY = groundY;
    //        IsGrounded = false;
    //    }

    //    public void Update(ref Vector2 position, InputState input, float dt)
    //    {
    //        // Horizontal
    //        Velocity = new Vector2(input.moveX * moveSpeed, Velocity.Y);

    //        // Jump
    //        if (input.jumpPressed && IsGrounded)
    //        {
    //            Velocity = new Vector2(Velocity.X, -jumpSpeed);
    //            IsGrounded = false;
    //        }

    //        // Gravity
    //        Velocity = new Vector2(Velocity.X, Velocity.Y + gravity * dt);

    //        position += Velocity * dt;

    //        // Temporary ground (until platform collision step)
    //        if (position.Y >= groundY)
    //        {
    //            position = new Vector2(position.X, groundY);
    //            Velocity = new Vector2(Velocity.X, 0f);
    //            IsGrounded = true;
    //        }
    //        else
    //        {
    //            IsGrounded = false;
    //        }
    //    }
    }
}
