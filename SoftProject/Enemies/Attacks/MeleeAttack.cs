using Microsoft.Xna.Framework;
using SoftProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.Attacks
{
    public class MeleeAttack : IAttackBehaviour
    {
        private int attackRange = 40;
        public void ExecuteAttack(Enemy attacker, Player target)
        {
            Rectangle enemyBox = attacker.Physics.CollisionBox;
            Rectangle attackBox;

            if (attacker.FacingLeft)
            {
                attackBox = new Rectangle(
                    enemyBox.Left - attackRange,
                    enemyBox.Top,
                    attackRange,
                    enemyBox.Height
                );
            }else
            {
                attackBox = new Rectangle(
                    enemyBox.Right,
                    enemyBox.Top,
                    attackRange,
                    enemyBox.Height
                );
            }

            if (attackBox.Intersects(target.Physics.CollisionBox))
            {
                target.Health--;
            }
        }
    }
}
