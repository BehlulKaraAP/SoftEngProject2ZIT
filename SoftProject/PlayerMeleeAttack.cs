using Microsoft.Xna.Framework;
using SoftProject.Enemies;
using SoftProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject
{
    public class PlayerMeleeAttack : IPlayerAttackBehavior
    {
        private int attackRange = 50;
        public void ExecuteAttack(Player attacker, List<Enemy> enemies)
        {
            Rectangle playerBox = attacker.Physics.CollisionBox;
            Rectangle attackBox;

            if (attacker.facingLeft)
            {
                attackBox = new Rectangle(playerBox.Left - attackRange, playerBox.Top, attackRange, playerBox.Height);
            }
            else
            {
                attackBox = new Rectangle(playerBox.Right, playerBox.Top, attackRange, playerBox.Height);
            }

            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsDead && attackBox.Intersects(enemy.Physics.CollisionBox))
                {
                    enemy.Health--;
                }
            }
        }
    }
}
