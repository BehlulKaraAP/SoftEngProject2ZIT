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

        public void Update(Enemy enemy, GameTime gameTime)
        {
            float distanceToPlayer = Vector2.Distance(enemy.Position, enemy.TargetPlayer.position);
            if (distanceToPlayer < 150)
            {
                enemy.ChangeState(new ChaseState());
                return;
            }

            if (enemy.Physics.Velocity.X == 0 || IsAtEdge(enemy))
            {
                enemy.FacingLeft = !enemy.FacingLeft; 
            }

            if (enemy.FacingLeft)
            {
                enemy.Physics.Velocity.X = -speed;
            }
            else
            {
                enemy.Physics.Velocity.X = speed;
            }
        }

        private bool IsAtEdge(Enemy enemy)
        {
            Rectangle box = enemy.Physics.CollisionBox;

            int sensorWidth = 5;
            int sensorHeight = 5;

            int lookAheadX = enemy.FacingLeft ? (box.Left - sensorWidth) : box.Right;
            int lookAheadY = box.Bottom + 2;

            Rectangle edgeSensor = new Rectangle(lookAheadX, lookAheadY, sensorWidth, sensorHeight);

            foreach (Rectangle rect in enemy.Level.CollisionRectangles)
            {
                if (edgeSensor.Intersects(rect))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
