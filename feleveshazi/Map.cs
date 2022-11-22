using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    internal class Map
    {
        public int mapHossz { get;}
        public Map(int mapHossz)
        {
            this.mapHossz = mapHossz;
        }
        public void MapKiiratas()
        { 
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < mapHossz; i++)
            {
                Console.Write('-');
            }
            for (int i = 0; i < mapHossz; i++)
            {
                Console.SetCursorPosition(i, 6);
                Console.Write('-');
            }
        }
    }
}
