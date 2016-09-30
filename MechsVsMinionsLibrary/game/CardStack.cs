using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class CardStack
    {
        public int Power { get; set; }
        public string Color { get; set; }
        public Card Card { get; set; }

        public void AddCard(Card c)
        {
            if (this.Card == null || !this.Color.Equals(c.Color))
            {
                this.Power = 1;
                this.Color = c.Color;
                this.Card = c;
            } else
            {
                this.Power += 1;
                this.Card = c;
            }
        }
    }
}
