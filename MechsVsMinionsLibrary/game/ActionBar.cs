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

        public override string ToString()
        {
            StringBuilder commandline = new StringBuilder();
            commandline.Append("=======================================================\n");
            commandline.Append("=   0    =   1    =   2    =   3    =   4    =   5    =\n");
            commandline.Append("=======================================================\n");
            for (int i = 0; i < 6; i++)
            {
                if (cards[i].Card != null)
                    commandline.Append("=" + len8(cards[i].Card.Name));
                else
                    commandline.Append("=        ");
            }
            commandline.Append("=\n");
            for (int i = 0; i < 6; i++)
            {
                if (cards[i].Card != null)
                    commandline.Append("=" + len8(cards[i].Card.Color));
                else
                    commandline.Append("=        ");
            }
            commandline.Append("=\n");
            commandline.Append("=======================================================\n");
            return commandline.ToString();

        }

        private string len8(string data)
        {
            StringBuilder d = new StringBuilder(data.Substring(0, Math.Min(8, data.Length)));
            while (d.Length != 8)
                d.Append(' ');
            return d.ToString();
        }

    }
}
