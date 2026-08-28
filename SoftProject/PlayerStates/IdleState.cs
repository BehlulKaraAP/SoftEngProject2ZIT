using Microsoft.Xna.Framework.Input;
using SoftProject.PlayerState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.PlayerStates
{
    public class IdleState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.PlayAnimation("Idle");
        }

        public void Update(Player player)
        {
            var direction = player.InputReader.ReadInput();
            if (direction.X != 0)
            {
                player.ChangeState(new RunState());
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                player.ChangeState(new AttackState());
                return; 
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && player.IsGrounded)
            {
                player.ChangeState(new JumpState());
                return;
            }
        }
    }
}
