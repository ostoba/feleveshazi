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
            Zombie tesztzombie = new Zombie();
            Jatek(tesztzombie, map, towerek);
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
        static void Jatek(Zombie zombik, Map map, Tower[] towerek)
        {
            map.MapKiiratas();
            towerKiiratas(towerek);
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Indulhat a jatek? ('Start')");
            string asd = Console.ReadLine();
            if (asd=="Start")
            {
                while (!zombik.beErt(map))
                {
                    Console.Clear();
                    zombik.lepes();
                    zombik.zombieKiiratas();
                    map.MapKiiratas();
                    towerKiiratas(towerek);
                    Thread.Sleep(300);

                }
            }
        }

    }
}
