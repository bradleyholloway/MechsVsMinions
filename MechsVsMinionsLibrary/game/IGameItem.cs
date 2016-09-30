using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public interface IGameItem
    {
        void DamageFromMech();
        void DamageFromMinion();
    }
}
