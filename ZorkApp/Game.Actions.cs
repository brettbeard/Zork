//-----------------------------------------------------------------------
// <copyright file="Game.Actions.cs" company="public">
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
    using System.Linq;

    /// <summary>
    /// The Actions methods for the Game class.
    /// </summary>
    public partial class Game
    {
        /// <summary>
        /// Handles the action.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="context">The context.</param>
        private void HandleAction(ActionParameters parameters, GameContext context)
        {
            switch (parameters.Action)
            {
                case Actions.Inventory:
                    this.OutputText("Inventory.");
                    break;
                case Actions.Walk:
                    this.HandleWalk(parameters.DirectOjbect, context);
                    break;
                case Actions.Open:
                    this.HandleOpen(parameters.DirectOjbect, context);
                    break;
                case Actions.Close:
                    this.HandleClose(parameters.DirectOjbect, context);
                    break;
                case Actions.Read:
                    this.HandleRead(parameters.DirectOjbect, context);
                    break;
            }
        }

        /// <summary>
        /// Handles the walk.
        /// </summary>
        /// <param name="directObject">The direct object.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private void HandleWalk(String directObject, GameContext context)
        {
            Exit exit = null;
            if (directObject == "north" || directObject == "n")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.North
                        select item).FirstOrDefault();
            }
            else if (directObject == "nw")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.NorthWest
                        select item).FirstOrDefault();
            }
            else if (directObject == "ne")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.NorthEast
                        select item).FirstOrDefault();
            }
            else if (directObject == "south" || directObject == "s")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.South
                        select item).FirstOrDefault();
            }
            else if (directObject == "sw")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.SouthWest
                        select item).FirstOrDefault();
            }
            else if (directObject == "se")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.SouthEast
                        select item).FirstOrDefault();
            }
            else if (directObject == "west" || directObject == "w")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.West
                        select item).FirstOrDefault();
            }
            else if (directObject == "east" || directObject == "e")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.East
                        select item).FirstOrDefault();
            }
            else if (directObject == "up")
            {
                exit = (from item in context.CurrentLocation.Exits
                        where item.Direction == Direction.Up
                        select item).FirstOrDefault();
            }

            if (exit != null)
            {
                if (String.IsNullOrEmpty(exit.Text))
                {
                    context.CurrentLocation = this.locations[exit.Location];
                }
                else
                {
                    this.OutputText(exit.Text);
                }
            }
        }

        /// <summary>
        /// Handles the open.
        /// </summary>
        /// <param name="directObject">The direct object.</param>
        /// <param name="context">The context.</param>
        private void HandleOpen(String directObject, GameContext context)
        {
            foreach (var thing in context.CurrentLocation.Things)
            {
                if (thing.GetType() == typeof(ZorkContainer))
                {
                    if (thing.Name.Equals(directObject))
                    {
                        ZorkContainer container = (ZorkContainer)thing;
                        if (container.IsOpen == false)
                        {
                            container.IsOpen = true;

                            String text = String.Format("Opening the {0} reveals {1}.", container.Description, container.Things[0].Description);
                            this.OutputText(text);
                        }
                        else
                        {
                            this.OutputText("It is already open.");
                        }
                    }

                }
                else if(thing.GetType() == typeof(ZorkDoor))
                {
                    ZorkDoor door = (ZorkDoor)thing;
                    if (door.IsOpen == false)
                    {
                        this.OutputText(door.OpenText);
                        door.IsOpen = true;
                    }
                    else
                    {
                        this.OutputText("Nothing to open.");
                    }
                }
            }           
        }

        /// <summary>
        /// Handles the close.
        /// </summary>
        /// <param name="directObject">The direct object.</param>
        /// <param name="context">The context.</param>
        private void HandleClose(String directObject, GameContext context)
        {
            ZorkDoor door = (ZorkDoor)(from item in context.CurrentLocation.Things
                                       where item.GetType() == typeof(ZorkDoor)
                                       select item).FirstOrDefault();

            if (door != null)
            {
                if (door.IsOpen == true)
                {
                    this.OutputText(door.CloseText);
                    door.IsOpen = false;
                }
            }
            else
            {
                this.OutputText("Nothing to close.");
            }
        }

        private void HandleRead(String directObject, GameContext context)
        {
            Boolean handled = false;
            foreach (var thing in context.CurrentLocation.Things)
            {
                if (thing.GetType() == typeof(ZorkContainer))
                {
                    ZorkContainer container = (ZorkContainer)thing;
                    if (container.IsOpen == true)
                    {
                        foreach (var subThing in container.Things)
                        {
                            if (subThing.IsReadable)
                            {                                
                                this.OutputText(subThing.Text);
                                handled = true;
                            }
                        }
                            
                    }
                }

                //if (thing.IsReadable)
                //{
                //    //String text = String.Format("Opening the {0} reveals {1}.", container.Description, container.Things[0].Description);
                //    this.OutputText(thing.Text);
                //}                
            }

            if (handled == false)
            {
                String text = String.Format("You can't see any {0} here!", directObject);
                this.OutputText(text);
            }
        }
    }
}
