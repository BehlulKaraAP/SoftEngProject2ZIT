using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public class ChaseState : IEnemyState
    {
        private float chaseSpeed = 1.5f;
        public void Enter(Enemy enemy)
        {
            enemy.PlayAnimation("Patrol");
        }

        public void Update(Enemy enemy)
        {
            float distanceToPlayer = Vector2.Distance(enemy.Position, enemy.TargetPlayer.position);

            if (distanceToPlayer > 200)
            {
                enemy.ChangeState(new PatrolState());
                return;
            }

            if (enemy.TargetPlayer.position.X < enemy.Position.X)
            {
                enemy.Physics.Velocity.X = -chaseSpeed;
                enemy.FacingLeft = true;
            }
            else if (enemy.TargetPlayer.position.X > enemy.Position.X)
            {
                enemy.Physics.Velocity.X = chaseSpeed;
                enemy.FacingLeft = false;
            }
        }
    }
}
