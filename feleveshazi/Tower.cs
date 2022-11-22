using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        public void loves(Zombie[] zombik)
        {
            #region probalkozasok
            //kozelseget probal nezni
            //for (int i = 0; i < zombik.Length; i++)
            //{
            //    int[] rangek = new int[range];
            //    for (int a = 1; a < rangek.Length + 1; a++)
            //    {
            //        rangek[i] = a;
            //    }
            //    if (cooldown == 0)
            //    {
            //        if (zombik[i].index == j)
            //        {
            //            zombik[i].index = -1;
            //            cooldown = 5;
            //        }
            //        //tower elott rangen belul
            //        else if (zombik[i].index >= minRange && j > zombik[i].index)
            //        {
            //            for (int a = 0; a < rangek.Length+1; a++)
            //            {
            //                //tower bal oldala
            //                if (Math.Abs(rangek[a]-j) == 1)
            //                {

            //                }
            //                else if (true)
            //                {

            //                }

            //            }
            //            zombik[i].index = -1;
            //            cooldown = 5;
            //        }
            //        //tower felett

            //        //tower utan rangen belul
            //        else if (zombik[i].index > j && maxRange >= zombik[i].index)
            //        {
            //            for (int a = j + 1; a < maxRange; a++)
            //            {
            //                if (zombik[a].index != -1)
            //                {
            //                    zombik[a].index = -1;
            //                    cooldown = 5;
            //                }
            //            }
            //        }
            //    }
            //}
            //kozelseget nem nez
            //for (int i = 0; i < zombik.Length; i++)
            //{
            //    if (cooldown == 0)
            //    {
            //        if (zombik[i].index == j)
            //        {
            //            zombik[i].index = -1;
            //            cooldown = 5;
            //        }
            //        else if (zombik[i].index >= minRange && j > zombik[i].index)
            //        {
            //            int hol = 1;
            //            while (hol <= range)
            //            {
            //                hol++;
            //            }
            //            zombik[i].index = -1;
            //            cooldown = 5;
            //        }
            //        else if (zombik[i].index > j && maxRange >= zombik[i].index)
            //        {
            //            zombik[i].index = -1;
            //            cooldown = 5;
            //        }
            //    }
            //}
            #endregion probalkozasok
            for (int i = 0; i < zombik.Length; i++)
            {
                if (cooldown == 0)
                {
                    if (zombik[i].index == j)
                    {
                        zombik[i].index = -1;
                        cooldown = 5;
                    }
                    else if ((zombik[i].index >= minRange && j > zombik[i].index))
                    {
                        int hol = 1;
                        while (hol < range + 1)
                        {
                            //j 5 z 2 range 3
                            if (zombik[i].index == j - hol)
                            {
                                zombik[i].index = -1;
                                cooldown = 5;
                                hol = range + 1;
                            }
                            else
                            {
                                hol++;
                            }
                        }
                    }
                    else if ((zombik[i].index > j && maxRange >= zombik[i].index))
                    {
                        int hol = 1;
                        while (hol < range + 1)
                        {
                            if (zombik[i].index == j + hol)
                            {
                                zombik[i].index = -1;
                                cooldown = 5;
                                hol = range + 1;
                            }
                            else
                            {
                                hol++;
                            }
                        }
                    }
                }
            }
        }
    }
}