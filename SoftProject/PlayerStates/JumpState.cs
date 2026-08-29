using SoftProject.PlayerState;

namespace SoftProject.PlayerStates
{
    public class JumpState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.PlayAnimation("Jump");

            player.Physics.Velocity.Y = player.Physics.JumpForce;
            player.Physics.IsGrounded = false;
        }

        public void Update(Player player)
        {
            if (player.Physics.IsGrounded)
            {
                if (player.Physics.Velocity.X != 0)
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
