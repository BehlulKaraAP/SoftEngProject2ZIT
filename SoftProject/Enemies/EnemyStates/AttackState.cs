using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public class AttackState : IEnemyState
    {
        public void Enter(Enemy enemy)
        {
        }

        public void Update(Enemy enemy)
        {
            enemy.AttackBehavior.ExecuteAttack(enemy, enemy.TargetPlayer);

        }
    }
}
