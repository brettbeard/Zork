//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="public">
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
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public enum Commands
    {
        Unknown,
        Quit,
        Move        
    }

    public enum LocationIds
    {
        WestOfHouse,
        EastOfHouse,
        NorthOfHouse,
        SouthOfHouse,
        Forest1,
        Forest2,
        Forest3,
        Path,
        Clearing,
        Mountains
    }

    /// <summary>
    /// Game class.
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// The syntaxes.
        /// </summary>
        private Collection<Syntax> syntaxes = new Collection<Syntax>();

        /// <summary>
        /// The locations.
        /// </summary>
        private Dictionary<LocationIds, ZorkLocation> locations = new Dictionary<LocationIds, ZorkLocation>();

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            var context = new GameContext();

            this.Initialize();

            // Start off North of the house
            context.CurrentLocation = this.locations[LocationIds.WestOfHouse];

            this.DisplayTitle();

            Boolean done = false;
            while (!done)
            {
                // Display description
                this.OutputDescription(context);

                // Get user input
                this.OutputCursor();
                String userInput = Console.ReadLine().ToLower();

                if (userInput.Length > 0)
                {
                    // Process input
                    var result = this.ProcessUserInput(context, userInput);

                    if (result.Action == Actions.Undefined)
                    {
                        this.OutputText("Invalid input.");
                    }
                    else if (result.Action == Actions.Quit)
                    {
                        // TBD - Are you sure?
                        done = true;
                    }
                    else
                    {
                        this.HandleAction(result, context);
                    }
                }
                else
                {
                    this.OutputText("I beg your pardon?");
                }
            }
        }        

        /// <summary>
        /// Outputs the description.
        /// </summary>
        /// <param name="context">The context.</param>
        private void OutputDescription(GameContext context)
        {
            this.OutputText(String.Empty);
            this.OutputText(context.CurrentLocation.Name);
            this.OutputText(context.CurrentLocation.Description);

            if (context.CurrentLocation.Things.Count > 0)
            {
                foreach (var item in context.CurrentLocation.Things)
                {
                    if (item.GetType() == typeof(ZorkContainer))
                    {
                        ZorkContainer thing = (ZorkContainer)item;

                        String text = String.Format("There is a {0} here.", item.Description);
                        this.OutputText(text);

                        if (thing.IsOpen)
                        {
                            text = String.Format("The {0} contains:", item.Description);
                            this.OutputText(text);

                            foreach (var subThing in thing.Things)
                            {
                                text = String.Format("A {0}", subThing.Description);
                                this.OutputText(text);                                
                            }
                        }
                    }
                }
            }            
        }

        /// <summary>
        /// Parses the user input.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <returns></returns>
        private ActionParameters ProcessUserInput(GameContext context, String userInput)
        {
            var results = new ActionParameters();
            results.Action = Actions.Undefined;

            // Break the input up into words
            var words = userInput.Split(' ');

            String verb = String.Empty;
            String directObject = String.Empty;
            String indirectObject = String.Empty;

            // Look for first verbs in words
            foreach (var word in words)
            {
                // Is this word in our vocabulary?
                var item = context.Vocabulary.LookUp(word);
                if (item != null)
                {
                    // Found the word

                    // Is the word a verb?
                    if (item.Category == WordCategory.Verb)
                    {
                        // Found the verb - now exit the loop
                        verb = item.Text;                        
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(verb) == false)
                    {
                        if (String.IsNullOrEmpty(directObject))
                        {
                            directObject = word;
                        }
                        else
                        {
                            indirectObject = word;
                        }
                    }
                }
            }

            // No verb?
            if (String.IsNullOrEmpty(verb))
            {
                // Is this word in our vocabulary?
                var item = context.Vocabulary.LookUp(words[0]);
                if (item != null)
                {
                    if (item.IsDirection)
                    {
                        verb = "walk";
                        directObject = words[0];
                    }
                }
            }

            // Find the action            

            // Locate action
            var syntaxItems = (from cust in this.syntaxes
                               where cust.Verb == verb
                               select cust).ToList();

            if (syntaxItems.Count == 1)
            {
                results.Action = syntaxItems[0].Action;
                results.DirectOjbect = directObject;
                results.IndirectOjbect = indirectObject;
            }
            else
            {
            }

            return results;
        }

        /// <summary>
        /// Displays the title.
        /// </summary>
        private void DisplayTitle()
        {
            this.OutputText("ZORK I: The Great Underground Empire");
        }

        /// <summary>
        /// Outputs the text.
        /// </summary>
        /// <param name="text">The text.</param>
        private void OutputText(String text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Outputs the cursor.
        /// </summary>
        private void OutputCursor()
        {
            Console.Write("\n > ");
        }
    }

    public class Syntax
    {
        private Collection<String> items = new Collection<string>();

        public String Verb { get; set; }

        public Collection<string> Items { get => this.items; }

        public Actions Action { get; set; }
        
    }

    public enum Actions
    {
        Undefined,
        Verbose,
        Brief,
        Super,
        Diagnose,        
        Inventory,
        Quit,
        Walk,
        WalkAround,
        Open,
        Close,
        Read
    }

    public class ActionParameters
    {
        public Actions Action { get; set; }

        public String DirectOjbect { get; set; }

        public String IndirectOjbect { get; set; }
    }
}
