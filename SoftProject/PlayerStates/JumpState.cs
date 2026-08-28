using SoftProject.PlayerState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.PlayerStates
{
    public class JumpState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.PlayAnimation("Jump");

            player.Velocity.Y = player.JumpForce;
            player.IsGrounded = false;
        }

        public void Update(Player player)
        {
            if (player.IsGrounded)
            {
                if (player.Velocity.X != 0)
                {
                    player.ChangeState(new RunState());
                }
                else
                {
                    player.ChangeState(new IdleState());
                }
            }
        }
    }
}
