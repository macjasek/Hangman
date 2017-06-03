using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string> { "pies", "kot", "taczka", "worek" };
            Random rnd = new Random();
            int wordIndex = rnd.Next(0, words.Count);
            var wordToGuess = words.ElementAt(wordIndex);
            var wordLen = wordToGuess.Length;
            var stars = "";

            Console.WriteLine($"Zgadnij słowo:");

            for (int i = 0; i < wordLen; i++)
            {
                stars += "*";
            }
            Console.WriteLine(stars);

            var letter = "x";


            var lettersInWordToGuess = wordToGuess.Distinct();
            var lettersGuessed = new List<char> { };

            while (true)
            {
                letter = Console.ReadLine();
                
                if (wordToGuess.Contains(letter))
                {
                    Console.WriteLine("Zgadłeś literę");
                    lettersGuessed.Add(letter[0]);
                    WriteWord(lettersGuessed, wordToGuess);
                }
                else
                {
                    Console.WriteLine("Nie odgadłeś litery");
                }

                if (lettersInWordToGuess.Count() == lettersGuessed.Count) 
                {
                    Console.WriteLine($"Brawo zgadłeś wszystkie litery w słowie {wordToGuess}");
                    break;
                }

                Console.WriteLine($"Zgadnij słowo:");
            }
        }

        static void WriteWord(List<char> list, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (!list.Contains(word[i]))
                {
                    word = word.Replace(word[i], '*');
                }
            }
            Console.WriteLine(word);
        }
    }
}
