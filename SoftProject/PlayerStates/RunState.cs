using Microsoft.Xna.Framework.Input;
using SoftProject.PlayerState;

namespace SoftProject.PlayerStates
{
    public class RunState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.PlayAnimation("Run");
        }

        public void Update(Player player)
        {
            var direction = player.InputReader.ReadInput();
            if (direction.X == 0)
            {
                player.ChangeState(new IdleState());
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                player.ChangeState(new AttackState());
                return; 
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && player.Physics.IsGrounded)
            {
                player.ChangeState(new JumpState());
                return;
            }
        }
    }
}
