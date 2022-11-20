using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace feleveshazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tower[] towerek = towerLetrehozas();
            Map map = mapLetrehozas();
            Zombie[] zombik = zombieLetrehozas();
            Jatek(zombik, map, towerek);
            Console.ReadLine();
        }
        static Tower[] towerLetrehozas()
        {
            Random r = new Random();
            Tower[] towerek = new Tower[5];
            int[] helyek = new int[5] { -1, -1, -1, -1, -1 };
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i] = new Tower(r, helyek);
                helyek[i] = towerek[i].j;
                //Console.WriteLine("helyek {0} tower.j {1}", helyek[i], towerek[i].j);
            }
            return towerek;
        }
        static void towerKiiratas(Tower[] towerek)
        {
            Random r = new Random();
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i].towerKiiratas(r);
            }
        }
        static Map mapLetrehozas()
        {
            Map map = new Map(50);
            return map;
        }
        static Zombie[] zombieLetrehozas()
        {
            Zombie[] zombik = new Zombie[5];
            for (int i = 0; i < zombik.Length; i++)
            {
                zombik[i] = new Zombie();
            }
            return zombik;
        }
        static void Jatek(Zombie[] zombik, Map map, Tower[] towerek)
        {
            map.MapKiiratas();
            towerKiiratas(towerek);
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Indulhat a jatek? ('Start')");
            string asd = Console.ReadLine();
            if (asd=="Start")
            {
                while (!jatekVege(zombik, map))
                {
                    towerLoves(towerek, zombik, map);
                    //cooldown ++, lo a tower ha 0 a cd, range-n beluli zombiekat
                    Console.Clear();
                    zombikLeptetese(zombik,towerek);
                    zombiKiiratas(zombik);
                    map.MapKiiratas();
                    Console.WriteLine();
                    Console.WriteLine("tower cd {0} indexe {1}", towerek[0].cooldown, towerek[0].j);
                    Console.WriteLine("tower cd {0} indexe {1}", towerek[1].cooldown, towerek[1].j);
                    Console.WriteLine("tower cd {0} indexe {1}", towerek[2].cooldown, towerek[2].j);
                    Console.WriteLine("tower cd {0} indexe {1}", towerek[3].cooldown, towerek[3].j);
                    Console.WriteLine("tower cd {0} indexe {1}", towerek[4].cooldown, towerek[4].j);
                    towerKiiratas(towerek);
                    Thread.Sleep(300);
                }
            }
        }
        static bool jatekVege(Zombie[] zombik, Map map)
        {
            //beert egy zombie, vagy nem maradt zombie
            bool vegevan = false;
            int[] zombikIndexe = new int[zombik.Length];
            for (int i = 0; i < zombik.Length; i++)
            {
                zombikIndexe[i] = zombik[i].index;
            }
            if (zombikIndexe.Contains(map.mapHossz-1))
            {
                return true;
            }
            return vegevan;
        }
        static void zombikLeptetese(Zombie[] zombik, Tower[] towerek)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                zombik[i].lepes();
                towerek[i].cooldown--;
            }
            
        }
        static void zombiKiiratas(Zombie[] zombik)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                zombik[i].zombieKiiratas();
            }
        }
        static void towerLoves(Tower[] towerek, Zombie[] zombik, Map map)
        {
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i].loves(zombik, map);
            }
        }
    }
}
