using MechsVsMinionsLibrary.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.util
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Location LocationWithTileOffset(Mech mech, Tile tile)
        {
            Location temp = mech.Location;
            if (tile.Forward > 0)
            {
                for (int i = 0; i < tile.Forward; i++)
                {
                    temp = temp.AdjacentDirection(mech.Direction);
                }
            }
            else
            {
                for (int i = 0; i < -tile.Forward; i++)
                {
                    temp = temp.AdjacentDirection(mech.Direction + 4);
                }
            }
            if (tile.Right > 0)
            {
                for (int i = 0; i < tile.Right; i++)
                {
                    temp = temp.AdjacentDirection(mech.Direction + 2);
                }
            }
            else 
            {
                for (int i = 0; i < -tile.Right; i++)
                {
                    temp = temp.AdjacentDirection(mech.Direction + 6);
                }
            }
            return temp;
        }
        public static Location MovementWithTileOffset(Mech mech, Tile tile, GameBoard board)
        {
            Location temp = mech.Location;
            if (tile.Forward > 0)
            {
                temp = temp.AdjacentDirection(mech.Direction);
                for (int i = 0; i < tile.Forward; i++)
                {
                    if (board.GetTerrain(temp) != null && board.GetGameItem(temp) == null)
                        temp = temp.AdjacentDirection(mech.Direction);
                }
                temp = temp.AdjacentDirection(mech.Direction + 4);
            }
            else if (tile.Forward < 0)
            {
                temp = temp.AdjacentDirection(mech.Direction + 4);
                for (int i = 0; i < -tile.Forward; i++)
                {
                    if (board.GetTerrain(temp) != null && board.GetGameItem(temp) == null)
                        temp = temp.AdjacentDirection(mech.Direction + 4);
                }
                temp = temp.AdjacentDirection(mech.Direction);
            }
            if (tile.Right > 0)
            {
                temp = temp.AdjacentDirection(mech.Direction + 2);
                for (int i = 0; i < tile.Right; i++)
                {
                    if (board.GetTerrain(temp) != null && board.GetGameItem(temp) == null)
                        temp = temp.AdjacentDirection(mech.Direction + 2);
                }
                temp = temp.AdjacentDirection(mech.Direction + 6);
            }
            else if (tile.Right < 0)
            {
                temp = temp.AdjacentDirection(mech.Direction + 6);
                for (int i = 0; i < -tile.Right; i++)
                {
                    if (board.GetTerrain(temp) != null && board.GetGameItem(temp) == null)
                        temp = temp.AdjacentDirection(mech.Direction + 6);
                }
                temp = temp.AdjacentDirection(mech.Direction + 2);
            }
            return temp;
        }

        public Location AdjacentDirection(int direction)
        {
            direction = direction % 8;
            switch (direction)
            {
                case 0:
                    return new Location(X + 1, Y);
                case 1:
                    return new Location(X + 1, Y + 1);
                case 2:
                    return new Location(X, Y + 1);
                case 3:
                    return new Location(X - 1, Y + 1);
                case 4:
                    return new Location(X - 1, Y);
                case 5:
                    return new Location(X - 1, Y - 1);
                case 6:
                    return new Location(X, Y - 1);
                case 7:
                    return new Location(X + 1, Y - 1);
            }
            return this;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}
