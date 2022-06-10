//-----------------------------------------------------------------------
// <copyright file="Vocabulary.cs" company="public">
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

    public class Vocabulary
    {
        private Dictionary<String, Word> words = new Dictionary<string, Word>();
        public Vocabulary()
        {
            this.Initialize();
        }

        public Word LookUp(String lookup)
        {
            Word word = null;

            if (this.words.TryGetValue(lookup, out word))
            {
            }

            return word;
        }

        private void Initialize()
        {
            this.words.Add("quit", new Word("quit", "quit", WordCategory.Verb, false));
            this.words.Add("q", new Word("q", "quit", WordCategory.Verb, false));
            this.words.Add("inventory", new Word("inventory", "inventory", WordCategory.Verb, false));
            this.words.Add("i", new Word("i", "inventory", WordCategory.Verb, false));
            this.words.Add("walk", new Word("walk", "walk", WordCategory.Verb, false));

            this.words.Add("open", new Word("open", "open", WordCategory.Verb, false));
            this.words.Add("close", new Word("close", "close", WordCategory.Verb, false));

            this.words.Add("read", new Word("read", "read", WordCategory.Verb, false));

            this.words.Add("north", new Word("north", "north", WordCategory.Noun, true));
            this.words.Add("n", new Word("n", "north", WordCategory.Noun, true));
            this.words.Add("south", new Word("south", "south", WordCategory.Noun, true));
            this.words.Add("s", new Word("s", "south", WordCategory.Noun, true));
            this.words.Add("east", new Word("east", "east", WordCategory.Noun, true));
            this.words.Add("e", new Word("e", "east", WordCategory.Noun, true));
            this.words.Add("west", new Word("west", "west", WordCategory.Noun, true));
            this.words.Add("w", new Word("w", "west", WordCategory.Noun, true));

            this.words.Add("ne", new Word("ne", "ne", WordCategory.Noun, true));
            this.words.Add("nw", new Word("nw", "nw", WordCategory.Noun, true));

            this.words.Add("se", new Word("se", "se", WordCategory.Noun, true));
            this.words.Add("sw", new Word("sw", "sw", WordCategory.Noun, true));
        }
    }

    public enum WordCategory
    {
        Unknown,
        Verb,
        Noun
    }

    public class Word
    {
        public String Text { get; set;  }

        public String Association { get; set; }

        public WordCategory Category { get; set; }

        public Boolean IsDirection { get; set; }

        public Word(String text, String association, WordCategory category, Boolean isDirection)
        {
            this.Text = text;
            this.Association = association;
            this.Category = category;
            this.IsDirection = isDirection;
        }
    }
}
