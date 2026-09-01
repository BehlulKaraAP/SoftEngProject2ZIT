using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public class DeathState : IEnemyState
    {
        private float _timeDying = 0f;
        private float _deathDuration = 1.0f;
        public void Enter(Enemy enemy)
        {
            enemy.PlayAnimation("Death");

            enemy.Physics.Velocity.X = 0;
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {

            if (enemy.CurrentAnimator.Animation.IsComplete)
            {
                enemy.AnimationFinished = true;
            }
        }
    }
}
