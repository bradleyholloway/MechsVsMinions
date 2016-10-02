using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Linq;
using MechsVsMinionsLibrary.game;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using MechsVsMinionsLibrary.util;
using System.Collections.Generic;

namespace MechsVsMinions
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MechsVsMinions : Microsoft.Xna.Framework.Game
    {


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MechsVsMinions()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            const string path = @"core_deck.xml";
            var curPath = Directory.GetCurrentDirectory();
            Log(curPath);
            StreamReader reader = new StreamReader(path, Encoding.UTF8);
            XmlSerializer xs = new XmlSerializer(typeof(Deck));
            Deck test = (Deck)xs.Deserialize(reader);

            GameBoard.loadBoard("file");
            Mech player = new Mech()
            {
                Location = new MechsVsMinionsLibrary.util.Location(0, 0),
                Direction = 0
            };
            GameBoard board = GameBoard.getInstance();
            player.PlaceOnBoard(board);

            /*
            player.ActionBar.Cards.ElementAt<CardStack>(2).AddCard(test.RandomCard);
            player.ActionBar.Cards.ElementAt<CardStack>(3).AddCard(test.RandomCard);
            player.ActionBar.Cards.ElementAt<CardStack>(1).AddCard(test.RandomCard);
            player.ActionBar.Cards.ElementAt<CardStack>(3).AddCard(test.RandomCard);
            */

            Random r = new Random();
            Console.WriteLine(board);
            while (player.Health > 0)
            {
                Console.WriteLine("Score: " + Minion.Kills);
                Console.WriteLine("Health: " + player.Health);

                Card cardDraw = test.RandomCard;
                Console.WriteLine("You drew a card: ");
                Console.WriteLine(cardDraw);

                Console.WriteLine("Current Command Line:");
                Console.WriteLine(player.ActionBar);

                Console.Write("Place on stack: ");
                int stack = -1;
                while (!int.TryParse(Console.ReadLine(), out stack) || stack < 0 || stack > 5)
                {
                    Console.Write("Place on stack: ");
                }
                player.ActionBar.Cards.ElementAt(stack).AddCard(cardDraw);

                //player execute
                player.Execute();

                //minion move
                int dir = r.Next(4) * 2;
                board.MoveMinions(dir);

                Console.WriteLine("Minions Spawning");
                //minion spawn
                

                for (int j = 0; j < 3; j ++)
                {
                    Minion m = new Minion()
                    {
                        Location = new Location(r.Next(5), r.Next(5))
                    };
                    m.PlaceOnBoard(board);
                }
                board.Display();

                //minion attack
                HashSet<Location> adjacent = new HashSet<Location>();
                adjacent.Add(player.Location.AdjacentDirection(0));
                adjacent.Add(player.Location.AdjacentDirection(2));
                adjacent.Add(player.Location.AdjacentDirection(4));
                adjacent.Add(player.Location.AdjacentDirection(6));
                foreach (Location spot in adjacent)
                {
                    if (board.GetGameItem(spot) != null)
                    {
                        if (board.GetGameItem(spot) is Minion)
                        {
                            player.Health--;
                        }
                    }
                }

            }

            Console.WriteLine("Final Score: " + Minion.Kills);
            while (true)
                Console.ReadLine();
            this.Exit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public static void Log(string logMessage)
        {
            /*
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
            */
        }
    }
}
