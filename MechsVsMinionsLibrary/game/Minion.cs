using MechsVsMinionsLibrary.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class Minion : IGameItem
    {
        public static int Kills = 0;
        public Location Location { get; set; }

        public void PlaceOnBoard(GameBoard board)
        {
            if (board.GetGameItem(Location) == null)
                board.Add(this, Location);
        }

        public void DamageFromMech()
        {
            Kills++;
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
