using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class BoardDisplayItem : IGameItem
    {
        private char c;
        public BoardDisplayItem(char c)
        {
            this.c = c;
        }

        public void DamageFromMech()
        {
            throw new NotImplementedException();
        }

        public void DamageFromMinion()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return c.ToString();
        }
    }
}
