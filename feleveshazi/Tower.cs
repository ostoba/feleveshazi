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
        public int minRange { get; set; }
        public int maxRange { get; set; }
        public Tower(Random r, int[] helyek, Map map)
        {
            int hely = r.Next(0, 50);
            while (vanEMarOttTower(helyek, hely))
            {
                hely = r.Next(0, 50);
            }
            j = hely;
            range = r.Next(1, 4);
            cooldown = 0;
            if (0 > j - range)
            {
                minRange = 0;
            }
            else
            {
                minRange = j - range;
            }
            if (j + range > map.mapHossz)
            {
                maxRange = map.mapHossz - 1;
            }
            else
            {
                maxRange = j + range;
            }
        }

        public void towerKiiratas(Random r)
        {
            Console.SetCursorPosition(j, 6);
            //ConsoleColor szin = (ConsoleColor)r.Next(1, 16);
            if (range == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (range == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (range == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write('O');
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }
        public bool vanEMarOttTower(int[] helyek, int j)
        {
            return helyek.Contains(j);
        }

        public bool vanEZombie(Zombie[] zombik, Map map)
        {
            bool vanE = false;
            //for (int i = 0; i < zombik.Length; i++)
            //{
            //    if (this.j - this.range > -1 && map.mapHossz > this.j + this.range)
            //    {
            //        if (zombik[i].index == this.j || zombik[i].index >= this.j - this.range || zombik[i].index <= this.j + this.range && this.cooldown == 0)
            //        {
            //            return true;
            //        }
            //    }
            //}
            for (int i = 0; i < zombik.Length; i++)
            {
                if (j == zombik[i].index)
                {
                    vanE = true;
                }
            }
            return vanE;
        }
        public void loves(Zombie[] zombik, Map map)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                if (cooldown == 0)
                {
                    if (zombik[i].index >= minRange && j >= zombik[i].index)
                    {
                        zombik[i].index = -1;
                        cooldown = 5;
                    }
                    else if (zombik[i].index == j)
                    {
                        zombik[i].index = -1;
                        cooldown = 5;
                    }
                    else if (zombik[i].index >= j && maxRange >= zombik[i].index)
                    {
                        zombik[i].index = -1;
                        cooldown = 5;
                    }
                }
            }
        }
    }
}