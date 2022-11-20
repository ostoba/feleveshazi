using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    class Tower
    {
        public int j { get; set; }
        public int range { get; set; }
        public int cooldown { get; set; }

        public Tower(Random r, int[] helyek)
        {
            int hely = r.Next(0,50);
            while (vanEMarOttTower(helyek,hely))
            {
                hely = r.Next(0,50);
            }
            j= hely;
            range = r.Next(1, 4);
            cooldown = 2;
        }

        public void towerKiiratas(Random r)
        {
            Console.SetCursorPosition(this.j, 6);
            //ConsoleColor szin = (ConsoleColor)r.Next(1, 16);
            if (range == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (range==2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write('O');
            Console.ResetColor();
            Console.SetCursorPosition(0,0);
        }
        public bool vanEMarOttTower(int[] helyek, int j)
        {
            return helyek.Contains(j);
        }
        public void loves()
        {

        }
    }
}
