using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Interfaces
{
    interface IWalkAway         // you can inherit as many classes as you want with interface
    {                           // everything is already public in interface // naming convention interfaces are always capitalized
        void WalkAway(Player player);
    }
}
