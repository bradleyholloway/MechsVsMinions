using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MechsVsMinionsLibrary.game
{

    public class Card
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }

        [XmlArray("Eff1"), XmlArrayItem("TurnAction", Type = typeof(TurnAction))]
        public List<TurnAction> Eff1 { get; set; }

        [XmlArray("Eff2"), XmlArrayItem("TurnAction", Type = typeof(TurnAction))]
        public List<TurnAction> Eff2 { get; set; }

        [XmlArray("Eff3"), XmlArrayItem("TurnAction", Type = typeof(TurnAction))]
        public List<TurnAction> Eff3 { get; set; }
    }
}
