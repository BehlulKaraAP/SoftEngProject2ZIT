using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Enemies.EnemyStates
{
    public interface IEnemyState 
    {
        void Enter(Enemy enemy);
        void Update(Enemy enemy);

    }
}
