using SoftProject.PlayerState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.PlayerStates
{
    public class AttackState : IPlayerState
    {
        public void Enter(Player player)
        {
            player.PlayAnimation("Attack");
            player.CurrentAnimator.Animation.Reset();
        }

        public void Update(Player player)
        {
            if (player.CurrentAnimator.Animation.IsComplete)
            {
                player.ChangeState(new IdleState());
            }
        }
    }
}
