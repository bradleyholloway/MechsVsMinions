using MechsVsMinionsLibrary.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class Minion : IGameItem
    {
        public Location Location { get; set; }

        public void PlaceOnBoard(GameBoard board)
        {
            board.Add(this, Location);
        }

        public void DamageFromMech()
        {
            GameBoard.getInstance().Remove(Location);
        }

        public void DamageFromMinion()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "M";
        }
    }
}
