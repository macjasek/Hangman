using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HangMan
{
    class PlayerList
    {
        public Dictionary<string, int> PlayersList {get; set;}
        public string Path { get; set; }

        public PlayerList()
        {
            Path = @".\PlayerList.txt";
            if (File.Exists(Path))
            {
                //Slownik
                PlayersList = new Dictionary<string, int>();
                //Wczytaj listę graczy
                using (var reader = new StreamReader(Path))
                {
                    while (!reader.EndOfStream)
                    {
                        var templLine = reader.ReadLine();
                        var tepmCharArr = templLine.Split(',');
                        PlayersList.Add(tepmCharArr[0], int.Parse(tepmCharArr[1]));
                    }

                }
                
            }
            else
            {
                File.Create(Path);
            }
        }

        public void SavePlayers()
        {
            using(var writer = File.CreateText(Path))
            {
                foreach (var item in PlayersList)
                {
                    writer.WriteLine($"{item.Key},{item.Value}");
                }
            }
            
            
        }

        public void PrintPlayerList()
        {
            Console.Clear();
            foreach (var item in PlayersList)
            {
                Console.WriteLine($"Gracz: {item.Key} Punkty: {item.Value}");   
            }
            Console.WriteLine("Przyciśj dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        public Player AddPlayerToList(string name)
        {
            if (!PlayersList.Keys.Contains(name))
            {
                //dodanie
                PlayersList.Add(name, 0);
            }
            //wczytanie
            var myPlayer = new Player(name,PlayersList[name]);
            return myPlayer;
        }
    }
}
