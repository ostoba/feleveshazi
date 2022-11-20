using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    internal class Zombie
    {
        public int index { get; set; }

        public Zombie()
        {
            this.index = 0;
        }
        public void lepes()
        {
            this.index += 1;
        }
        public void zombieKiiratas()
        {
            Console.SetCursorPosition(this.index, 3);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write('M');
            Console.ResetColor();
        }
        public bool beErt(Map map)
        {
            return index == map.mapHossz-1;
        }
    }
}
