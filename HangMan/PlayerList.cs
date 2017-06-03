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
        Dictionary<string, int> PlayersList {get; set;}
        public PlayerList()
        {
            var path = @".\PlayerList.txt";
            if (File.Exists(path))
            {
                //Wczytaj listę graczy

            }
            else
            {
                File.Create(path);
            }
        }
    }
}
