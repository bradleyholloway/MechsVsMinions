using MechsVsMinionsLibrary.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class Mech : IGameItem
    {
        public Mech()
        {
            this.ActionBar = new game.ActionBar();
        }

        public ActionBar ActionBar { get; set; }

        public Location Location { get; set; }
        public int Direction { get; set; }

        public void Execute()
        {
            foreach (CardStack stack in ActionBar.Cards)
            {
                Card c = stack.Card;
                int power = stack.Power;

                ActionHandler.Act(this, c, power);
            }
        }

        public void PlaceOnBoard(GameBoard board)
        {
            board.Add(this, this.Location);
        }

        public void DamageFromMech()
        {
            return;
        }

        public void DamageFromMinion()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            Direction %= 8;
            if (Direction == 0)
            {
                return ">";
            }
            if (Direction == 2)
            {
                return "v";
            }
            if (Direction == 4)
            {
                return "<";
            }
            if (Direction == 6)
            {
                return "^";
            }
            return "?";
        }
    }
}
