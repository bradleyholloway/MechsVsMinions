using MechsVsMinionsLibrary.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechsVsMinionsLibrary.game
{
    public class ActionHandler
    {
        private static void ExecuteAction(Mech mech, TurnAction action)
        {
            GameBoard board = GameBoard.getInstance();

            if (action.Type.Equals("Kill"))
            {
                ICollection<Location> targets = new HashSet<Location>();
                foreach (Tile tile in action.Tiles)
                {
                    Location temp = Location.LocationWithTileOffset(mech, tile);
                    
                    if (board.GetGameItem(temp) != null)
                        targets.Add(temp);
                }
                if (action.Count == 0 || targets.Count <= action.Count)
                {
                    foreach (Location l in targets)
                    {
                        IGameItem g = board.GetGameItem(l);
                        if (g != null)
                        {
                            g.DamageFromMech();
                        }
                    }
                }
                else
                {
                    // TODO: Prompt user for action.Count locations to kill.
                    for (int i = 0; targets.Count > 0 && i < action.Count; i++)
                    {
                        Location l = targets.First();
                        targets.Remove(l);
                        IGameItem gameItem = board.GetGameItem(l);
                        if (gameItem != null)
                        {
                            gameItem.DamageFromMech();
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
            }
            else if (action.Type.Equals("Projectile"))
            {
                Location temp = mech.Location;
                int direction = mech.Direction;

                if (action.Directions.Count == 1)
                {
                    direction += action.Directions.First();
                }
                else if (action.Directions.Count > 1)
                {
                    // TODO: Prompt User input of direction
                    direction += action.Directions.First();
                }



                temp = temp.AdjacentDirection(direction);
                int range = action.Range - 1;

                while (range != 0 && board.GetTerrain(temp) != null && board.GetGameItem(temp) == null && board.GetTerrain(temp).Projectile)
                {
                    temp = temp.AdjacentDirection(direction);
                }

                IGameItem gameItem = board.GetGameItem(temp);
                if (gameItem != null)
                {
                    gameItem.DamageFromMech();
                }
            }
            if (action.Type.Equals("Move"))
            {
                if (action.Tiles.Count == 1)
                {
                    Location temp = Location.LocationWithTileOffset(mech, action.Tiles.First());
                    if (board.GetTerrain(temp) != null && board.GetGameItem(temp) == null)
                    {
                        board.Remove(mech.Location);
                        mech.Location = temp;
                        board.Add(mech, mech.Location);
                    }
                }
                else if (action.Tiles.Count > 1)
                {
                    ICollection<Location> targets = new HashSet<Location>();
                    foreach (Tile tile in action.Tiles)
                    {
                        targets.Add(Location.MovementWithTileOffset(mech, tile, board));
                    }
                    // TODO: Select movement target from targets. (choose 1)
                    Location temp = targets.First();

                    board.Remove(mech.Location);
                    mech.Location = temp;
                    board.Add(mech, mech.Location);
                }
            }
            if (action.Type.Equals("Turn"))
            {
                if (action.Directions.Count == 1)
                {
                    mech.Direction += action.Directions.First();
                }
                else if (action.Directions.Count > 1)
                {
                    // TODO: Prompt user input of directions
                    mech.Direction += action.Directions.First();
                }
            }
        }

        public static void Act(Mech mech, Card card, int power)
        {
            if (card != null)
            {
                Console.WriteLine("Mech at location " + mech.Location + " Executing " + card.Name + " level " + power + ".");
                GameBoard board = GameBoard.getInstance();

                List<TurnAction> actions = new List<TurnAction>();
                if (power == 1)
                {
                    actions = card.Eff1;
                }
                else if (power == 2)
                {
                    actions = card.Eff2;
                }
                else if (power >= 3)
                {
                    actions = card.Eff3;
                }

                foreach (TurnAction action in actions)
                {
                    ExecuteAction(mech, action);
                }
                board.Display();
            }
        }
    }
}
