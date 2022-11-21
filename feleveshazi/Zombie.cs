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
            if (this.index!=-1)
            {
                this.index++;
            }
        }
        public void zombieKiiratas()
        {
            if (this.index!=-1)
            {
                Console.SetCursorPosition(this.index, 3);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('Z');
                Console.ResetColor();
            }
        }
        public bool beErtE(Map map)
        {
            return index == map.mapHossz-1;
        }
    }
}
