using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    internal class Map
    {
        public void MapKiiratas()
        { 
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 100; i++)
            {
                Console.Write('-');
            }
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(i, 5);
                Console.Write('-');
            }
        }
    }
}
