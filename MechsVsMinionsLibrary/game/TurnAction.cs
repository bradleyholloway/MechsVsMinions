using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MechsVsMinionsLibrary.game
{
    public class TurnAction
    {
        public string Type { get; set; }

        // Range on a projectile
        // Range = 0 means unlimited.
        public int Range { get; set; }

        // Count on number of enemies targetable by Kill
        // Note: Count = 0 means all tiles get killed.
        public int Count { get; set; }

        // Used for Move and Kill
        [XmlArray("Tiles"), XmlArrayItem("Tile", Type = typeof(Tile))]
        public List<Tile> Tiles { get; set; }

        /// <summary>
        /// Used for Tun options, and Projectile options.
        /// </summary>
        [XmlArray("Directions"), XmlArrayItem("Direction", Type = typeof(int))]
        public List<int> Directions { get; set; }
    }
}
