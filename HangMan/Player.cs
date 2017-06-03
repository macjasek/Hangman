using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Player
    {
        string Name { get; set; }
        int Points { get; set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
        }

        public void AddPoints(string player)
        {
            Points++;
        }
    }
}
