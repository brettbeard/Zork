//-----------------------------------------------------------------------
// <copyright file="ZorkLocation.cs" company="public">
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
    using System.Collections.ObjectModel;

    /// <summary>
    /// Zork location class.
    /// </summary>
    /// <seealso cref="ZorkApp.ZorkBase" />
    public class ZorkLocation : ZorkBase
    {
        /// <summary>
        /// The exits.
        /// </summary>
        private readonly Collection<Exit> exits = new();

        /// <summary>
        /// The things
        /// </summary>
        private readonly Collection<ZorkThing> things = new();       

        /// <summary>
        /// Gets the things.
        /// </summary>
        /// <value>
        /// The things.
        /// </value>
        public Collection<ZorkThing> Things => things;

        /// <summary>
        /// Gets the exits.
        /// </summary>
        /// <value>
        /// The exits.
        /// </value>
        public Collection<Exit> Exits => exits;
    }

    public enum Direction
    {
        North,
        South,
        East,
        West,
        NorthWest,
        NorthEast,
        SouthWest,
        SouthEast,
        Up,
        Down
    }

    public class Exit
    {
        public Direction Direction { get; set; }

        public LocationIds Location { get; set; }

        public String Text { get; set; }

        public Exit(Direction direction, LocationIds location)
        {
            this.Direction = direction;
            this.Location = location;
        }
    }
}
