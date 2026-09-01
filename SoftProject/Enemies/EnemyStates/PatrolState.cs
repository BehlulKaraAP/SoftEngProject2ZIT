using Microsoft.Xna.Framework;

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
            float distanceToPlayer = Vector2.Distance(enemy.Position, enemy.TargetPlayer.position);
            if (distanceToPlayer < 150)
            {
                enemy.ChangeState(new ChaseState());
                return;
            }

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
