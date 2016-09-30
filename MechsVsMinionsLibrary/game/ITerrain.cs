using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public interface ITerrain
    {
        bool Open { get; }
        bool Projectile { get; }
    }
}
