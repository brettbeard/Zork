//-----------------------------------------------------------------------
// <copyright file="Game.Initialize.cs" company="public">
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

namespace ZorkApp
{
    public partial class Game
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            this.InitializeSyntax();

            this.InitializeLocations();
        }

        /// <summary>
        /// Initializes the syntax.
        /// </summary>
        private void InitializeSyntax()
        {
            var syntax = new Syntax();
            syntax.Verb = "quit";
            syntax.Action = Actions.Quit;
            this.syntaxes.Add(syntax);

            syntax = new Syntax();
            syntax.Verb = "inventory";
            syntax.Action = Actions.Inventory;
            this.syntaxes.Add(syntax);

            //syntax = new Syntax();
            //syntax.Verb = "walk";
            //syntax.Action = Actions.WalkAround;
            //this.syntaxes.Add(syntax);

            syntax = new Syntax();
            syntax.Verb = "walk";
            syntax.Items.Add("<object>");
            syntax.Action = Actions.Walk;
            this.syntaxes.Add(syntax);

            syntax = new Syntax();
            syntax.Verb = "open";
            syntax.Items.Add("<object>");
            syntax.Action = Actions.Open;
            this.syntaxes.Add(syntax);

            syntax = new Syntax();
            syntax.Verb = "close";
            syntax.Items.Add("<object>");
            syntax.Action = Actions.Close;
            this.syntaxes.Add(syntax);

            syntax = new Syntax();
            syntax.Verb = "read";
            syntax.Items.Add("<object>");
            syntax.Action = Actions.Read;
            this.syntaxes.Add(syntax);
        }


        /// <summary>
        /// Initializes the locations.
        /// </summary>
        private void InitializeLocations()
        {
            var leaflet = new ZorkThing();
            leaflet.Name = "Leaflet";
            leaflet.Description = "leaflet";
            leaflet.IsReadable = true;
            leaflet.Text = "\"WELCOME TO ZORK!\nZORK is a game of adventure, danger, and low cunning. In it you will explore some of the most amazing territory ever seen by mortals.  No computer should be without one!\"";

            var mailbox = new ZorkContainer();
            mailbox.Name = "Mailbox";
            mailbox.Description = "small mailbox";
            mailbox.Things.Add(leaflet);

            var location = new ZorkLocation();
            location.Description = "You are standing in an open field west of a white house, with a boarded front door.";
            location.Name = "West of House";
            location.Exits.Add(new Exit(Direction.North, LocationIds.NorthOfHouse));
            location.Exits.Add(new Exit(Direction.South, LocationIds.SouthOfHouse));
            location.Exits.Add(new Exit(Direction.NorthEast, LocationIds.NorthOfHouse));
            location.Exits.Add(new Exit(Direction.SouthEast, LocationIds.SouthOfHouse));
            location.Exits.Add(new Exit(Direction.West, LocationIds.Forest1));
            location.Things.Add(mailbox);
            this.locations.Add(LocationIds.WestOfHouse, location);

            location = new ZorkLocation();
            location.Description = "You are facing the north side of a white house. There is no door here, and all the windows are boarded up.  To the north a narrow path winds through the trees.";
            location.Name = "North of House";
            location.Exits.Add(new Exit(Direction.SouthWest, LocationIds.WestOfHouse));
            location.Exits.Add(new Exit(Direction.SouthEast, LocationIds.EastOfHouse));
            location.Exits.Add(new Exit(Direction.West, LocationIds.WestOfHouse));
            location.Exits.Add(new Exit(Direction.East, LocationIds.EastOfHouse));
            location.Exits.Add(new Exit(Direction.North, LocationIds.Path));
            this.locations.Add(LocationIds.NorthOfHouse, location);

            location = new ZorkLocation();
            location.Description = "You are facing the south side of a white house. There is no door here, and all the windows are boarded.";
            location.Name = "South of House";
            location.Exits.Add(new Exit(Direction.West, LocationIds.WestOfHouse));
            location.Exits.Add(new Exit(Direction.East, LocationIds.EastOfHouse));
            location.Exits.Add(new Exit(Direction.NorthEast, LocationIds.EastOfHouse));
            location.Exits.Add(new Exit(Direction.NorthWest, LocationIds.WestOfHouse));
            location.Exits.Add(new Exit(Direction.West, LocationIds.Forest3));
            this.locations.Add(LocationIds.SouthOfHouse, location);

            location = new ZorkLocation();
            location.Description = "This is a forest, with trees in all directions. To the east, there appears to be sunlight.";
            location.Name = "Forest";
            //location.Exits.Add(new Exit(Direction.West, LocationIds.WestOfHouse));
            this.locations.Add(LocationIds.Forest1, location);

            var kitchenWindow = new ZorkDoor();
            kitchenWindow.Name = "KitchenWindow";
            kitchenWindow.OpenText = "With great effort, you open the window far enough to allow entry.";
            kitchenWindow.CloseText = "The window closes (more easily than it opened).";

            var eastOfHouse = new EastOfHouseLocation();
            eastOfHouse.Things.Add(kitchenWindow);
            this.locations.Add(LocationIds.EastOfHouse, eastOfHouse);

            location = new ZorkLocation();
            location.Description = "This is a path winding through a dimly lit forest. The path heads north - south here.One particularly large tree with some low branches stands at the edge of the path.";
            location.Name = "Forest path";
            location.Exits.Add(new Exit(Direction.South, LocationIds.NorthOfHouse));
            this.locations.Add(LocationIds.Path, location);

            location = new ZorkLocation();
            location.Description = "This is a dimly lit forest, with large trees all around.";
            location.Name = "Forest";
            location.Exits.Add(new Exit(Direction.South, LocationIds.NorthOfHouse));
            this.locations.Add(LocationIds.Forest2, location);

            location = new ZorkLocation();
            location.Description = "This is a dimly lit forest, with large trees all around.";
            location.Name = "Forest";
            location.Exits.Add(new Exit(Direction.South, LocationIds.NorthOfHouse));
            this.locations.Add(LocationIds.Forest3, location);
        }
    }
}
