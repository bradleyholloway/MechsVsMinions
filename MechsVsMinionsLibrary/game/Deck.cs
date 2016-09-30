using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MechsVsMinionsLibrary.game
{

    public class Deck
    {
        private Random r = new Random(1234);

        public int ID { get; set; }

        [XmlArray("CardList"), XmlArrayItem("Card", Type = typeof(Card))]
        public List<Card> CardList { get; set; }

        public Card RandomCard
        {
            get
            {
                return CardList.ElementAt<Card>(r.Next(CardList.Count));
            }
        }

        public override string ToString()
        {
            StringBuilder list = new StringBuilder();
            list.Append("Deck List:");
            foreach (Card c in CardList)
            {
                list.Append("\n" + c.Name + ", " + c.Color);
            }
            return list.ToString();
        }
    }
}
