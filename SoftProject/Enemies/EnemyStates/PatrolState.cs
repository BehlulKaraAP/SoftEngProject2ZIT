using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public class PatrolState : IEnemyState
    {
        private float speed = 1f;
        private bool movingRight = false;
        public void Enter(Enemy enemy)
        {
            enemy.PlayAnimation("Patrol");
        }

        public void Update(Enemy enemy)
        {
            if (enemy.Physics.Velocity.X == 0)
            {
                movingRight = !movingRight;
            }

            if (movingRight)
            {
                enemy.Physics.Velocity.X = speed;
                enemy.FacingLeft = false;
            }
            else
            {
                enemy.Physics.Velocity.X = -speed;
                enemy.FacingLeft = true;
            }
        }
    }
}
