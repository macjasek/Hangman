using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Game
    {
        
        public Game()
        {

        }

        public void PlayGame(Player myPlayer, string wordToGuess)
        {
            var wordLen = wordToGuess.Length;
            var stars = "";
            Console.Clear();
            Console.WriteLine($"Zgadnij słowo:");

            for (int i = 0; i < wordLen; i++)
            {
                stars += "*";
            }

            Console.WriteLine(stars);

            var letter = "x";


            var lettersInWordToGuess = wordToGuess.Distinct();
            var lettersGuessed = new List<char> { };
            var lines = 0;

            while (true)
            {
                letter = Console.ReadLine();

                if (wordToGuess.Contains(letter))
                {
                    Console.Clear();
                    Console.WriteLine("Zgadłeś literę");
                    lettersGuessed.Add(letter[0]);
                    WriteWord(lettersGuessed, wordToGuess);
                }
                else
                {
                    Console.WriteLine("Nie odgadłeś litery");
                    lines++;
                    if (lines > 8)
                    {
                        Console.WriteLine("Przegrałeś");
                        break;
                    }
                    DrawHangman(lines);
                }

                if (lettersInWordToGuess.Count() == lettersGuessed.Count)
                {
                    Console.WriteLine($"Brawo zgadłeś wszystkie litery w słowie {wordToGuess}");
                    myPlayer.AddPoints();
                    Console.WriteLine("Przyciśj dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
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

        static void DrawHangman(int lines)
        {
            var hangmanPicture = new string[8];
            hangmanPicture[0] = "  _______";
            hangmanPicture[1] = " |/      |";
            hangmanPicture[2] = " |      (_)";
            hangmanPicture[3] = @" |      \|/";
            hangmanPicture[4] = " |       |";
            hangmanPicture[5] = @" |      / \";
            hangmanPicture[6] = " |";
            hangmanPicture[7] = "_|___";
            Console.Clear();
            for (int i = 0; i < lines; i++)
            {

                Console.WriteLine(hangmanPicture[i]);
            }

        }
    }
}
