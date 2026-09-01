using SoftProject.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Interfaces
{
    public interface IPlayerAttackBehavior
    {
        void ExecuteAttack(Player attacker, List<Enemy> enemies);
    }
}
