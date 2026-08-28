using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.PlayerState
{
    public interface IPlayerState
    {
        void Enter(Player player);
        void Update(Player player);
    }
}
