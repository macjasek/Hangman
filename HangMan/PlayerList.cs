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

        public PlayerList()
        {
            var path = @".\PlayerList.txt";
            if (File.Exists(path))
            {
                //Slownik
                PlayersList = new Dictionary<string, int>();
                //Wczytaj listę graczy
                using (var reader = new StreamReader(path))
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
                File.Create(path);
            }
        }

        public void SavePlayers()
        {
            //tu będą się zapisywać gracze
        }

        public void PrintPlayerList()
        {
            foreach (var item in PlayersList)
            {
                Console.WriteLine($"Gracz: {item.Key} Punkty: {item.Value}");   
            }
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
