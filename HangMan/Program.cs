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
            var myWord = new WordsToGuess();
            var wordToGuess = myWord.NewWord();
            var myPlayerList = new PlayerList();

            Console.WriteLine("Wpisz swoje imię");
            var myPlayer = myPlayerList.AddPlayerToList(Console.ReadLine());
            
            PrintMenu();

            var option = 0;

            do
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var myGame = new Game();
                        myGame.PlayGame(myPlayer, wordToGuess);
                        myPlayerList.PlayersList[myPlayer.Name] = myPlayer.Points;

                        break;
                    case 2:
                        myPlayerList.PrintPlayerList();
                        break;
                    default:
                        break;
                }

                PrintMenu();
            } while (option != 3);

            myPlayerList.SavePlayers();
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Nowa Gra 2-Lista Wyników 3-Wyjście");
        }
    }
}
