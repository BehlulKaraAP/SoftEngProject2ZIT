using SoftProject.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Interfaces
{
    public interface IAttackBehaviour
    {
        void ExecuteAttack(Enemy attacker, Player target);
    }
}
