using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    class Tower
    {
        public int i { get; set;}
        public int j { get; set; }
        public int hatotavolsag { get; set; }
        //1 - piros, 2 - narancs, 3 - zold
        public int cooldown { get; set; }

        public Tower(Random r, int[] helyek)
        {
            i = 5;
            int hely = r.Next(0,100);
            while (vanEMarOttTower(helyek,hely))
            {
                hely = r.Next(0,100);
            }
            j= hely; 
            hatotavolsag = r.Next(1, 3);
            cooldown = 2;
        }

        public void Kiiratas(Random r)
        {
            Console.SetCursorPosition(this.j, this.i);
            //ConsoleColor szin = (ConsoleColor)r.Next(1, 16);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('O');
            Console.ResetColor();
            Console.SetCursorPosition(0,0);
        }
        public bool vanEMarOttTower(int[] helyek, int j)
        {
            return helyek.Contains(j);
        }
    }
}
