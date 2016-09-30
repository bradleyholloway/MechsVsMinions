using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class ActionBar
    {
        private CardStack[] cards = new CardStack[6] 
        { new CardStack(), new CardStack(), new CardStack(), new CardStack(), new CardStack(), new CardStack()};

        public CardStack[] Cards { get { return cards; } }

    }
}
