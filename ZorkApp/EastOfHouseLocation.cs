//-----------------------------------------------------------------------
// <copyright file="EastOfHouseLocation.cs" company="public">
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
    /// The East of house location class.
    /// </summary>
    /// <seealso cref="ZorkApp.ZorkLocation" />
    public class EastOfHouseLocation : ZorkLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EastOfHouseLocation"/> class.
        /// </summary>
        public EastOfHouseLocation()
        {            
            this.Name = "Behind House";
            this.Exits.Add(new Exit(Direction.North, LocationIds.NorthOfHouse));
            this.Exits.Add(new Exit(Direction.South, LocationIds.SouthOfHouse));
            this.Exits.Add(new Exit(Direction.SouthWest, LocationIds.SouthOfHouse));
            this.Exits.Add(new Exit(Direction.NorthWest, LocationIds.NorthOfHouse));            
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public override String Description
        {
            get
            {
                String text = "You are behind the white house. A path leads into the forest to the east.  In one corner of the house there is a small window which is ";

                if (this.KitchenWindow.IsOpen)
                {
                    text += "open.";
                }
                else
                {
                    text += "sligthly ajar.";
                }

                return text;
            }
        }

        /// <summary>
        /// Gets the kitchen window.
        /// </summary>
        /// <value>
        /// The kitchen window.
        /// </value>
        protected ZorkDoor KitchenWindow
        {
            get
            {
                // Look through the things for the KitchenWindow
                ZorkDoor kitchenWindow = (ZorkDoor)(from item in this.Things
                                                    where item.Name == "KitchenWindow"
                                                    select item).FirstOrDefault();

                return kitchenWindow;
            }
        }
    }
}
