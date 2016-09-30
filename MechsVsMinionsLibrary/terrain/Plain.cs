using MechsVsMinionsLibrary.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.terrain
{
    class Plain : ITerrain
    {
        public bool Open
        {
            get
            {
                return true;
            }
        }

        public bool Projectile
        {
            get
            {
                return true;
            }
        }
    }
}
