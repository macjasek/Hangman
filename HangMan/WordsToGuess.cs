using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    class WordsToGuess
    {
        string WordToGuess { get; set; }
        List<string> WordList { get; set; }

        public WordsToGuess()
        {
            var path = @".\wordsToGuess.txt";
            WordList = new List<string>();
            WordList.AddRange(File.ReadAllLines(path));
        }

        public string NewWord()
        {
            Random rnd = new Random();
            int wordIndex = rnd.Next(0, WordList.Count);           
            return WordList.ElementAt(wordIndex);
        }
    }
}
