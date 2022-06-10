﻿//-----------------------------------------------------------------------
// <copyright file="GameContext.cs" company="public">
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
    public class GameContext
    {
        /// <summary>
        /// The current location.
        /// </summary>
        private ZorkLocation currentLocation;

        /// <summary>
        /// The vocabulary
        /// </summary>
        private Vocabulary vocabulary = new Vocabulary();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameContext"/> class.
        /// </summary>
        public GameContext()
        {     
        }

        /// <summary>
        /// Gets or sets the current location.
        /// </summary>
        /// <value>
        /// The current location.
        /// </value>
        public ZorkLocation CurrentLocation { get => currentLocation; set => currentLocation = value; }

        /// <summary>
        /// Gets the vocabulary.
        /// </summary>
        /// <value>
        /// The vocabulary.
        /// </value>
        public Vocabulary Vocabulary { get => vocabulary; }     
    }    
}