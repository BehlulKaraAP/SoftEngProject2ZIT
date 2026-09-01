using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public class AttackState : IEnemyState
    {
        private float attackTimer = 0f;
        private float attackCooldown = 1f;
        public void Enter(Enemy enemy)
        {
            enemy.PlayAnimation("Attack");
            enemy.Physics.Velocity.X = 0;
            enemy.AttackBehavior.ExecuteAttack(enemy, enemy.TargetPlayer);
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            
            attackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds; 

            if (attackTimer >= attackCooldown)
            {
                enemy.ChangeState(new ChaseState());
            }

        }
    }
}
