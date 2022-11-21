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
            Map map = mapLetrehozas();
            Tower[] towerek = towerLetrehozas(map);
            Zombie[] zombik = zombieLetrehozas();
            Jatek(zombik, map, towerek);
            Console.ReadLine();
        }
        static Tower[] towerLetrehozas(Map map)
        {
            Random r = new Random();
            Tower[] towerek = new Tower[5];
            int[] helyek = new int[5] { -1, -1, -1, -1, -1 };
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i] = new Tower(r, helyek,map);
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
            Zombie[] zombik = new Zombie[15];
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
                int zombieszamlalo = 0;
                while (!jatekVege(zombik, map))
                {
                    towerLoves(towerek, zombik, map);
                    //cooldown ++, lo a tower ha 0 a cd, range-n beluli zombiekat
                    Console.Clear();
                    zombikLeptetese(zombik,towerek,zombieszamlalo);
                    if (zombieszamlalo!=zombik.Length)
                    {
                        zombieszamlalo++;
                    }
                    zombiKiiratas(zombik);
                    map.MapKiiratas();
                    Console.WriteLine();
                    for (int i = 0; i < towerek.Length; i++)
                    {
                        Console.WriteLine("tower cd {0} indexe {1} range {2} minrange {3} maxrange {4}", towerek[i].cooldown, towerek[i].j, towerek[i].range, towerek[i].minRange, towerek[i].maxRange);
                    }
                    for (int i = 0; i < zombik.Length; i++)
                    {
                        Console.WriteLine("zombi hol jar {0}, hanyadik zombie {1}", zombik[i].index, i);
                    }
                    towerKiiratas(towerek);
                    Thread.Sleep(500);
                }
                if (jatekVege(zombik,map))
                {
                    jatekVege(zombik,map);
                }
            }
        }
        static bool beErtEgyZombie(Zombie[] zombik, Map map)
        {
            bool beErt = false;
            for (int i = 0; i < zombik.Length; i++)
            {
                if (zombik[i].beErtE(map)==true)
                {
                    beErt = true;
                }
            }
            return beErt;
        }
        static bool nincsZombie(Zombie[] zombik)
        {
            bool meghaltak = false;
            double[] zombikIndexe = new double[zombik.Length];
            double atlag = 0;
            for (int i = 0; i < zombik.Length; i++)
            {
                zombikIndexe[i] = (double)zombik[i].index;
                atlag += (double)zombik[i].index;
            }
            atlag = atlag / zombik.Length;
            if (atlag == -1)
            {
                meghaltak = true;
            }
            return meghaltak;
        }
        static bool jatekVege(Zombie[] zombik, Map map)
        {
            //end screen
            bool vegeVan = false;
            if (nincsZombie(zombik) == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A jateknak vege!");
                Console.WriteLine("Nem maradt tobb zombie!");
                Console.ResetColor();
                vegeVan = true;
            }
            if (beErtEgyZombie(zombik,map))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A jateknak vege!");
                Console.WriteLine("Beert egy zombie a celba!");
                Console.ResetColor();
                vegeVan = true;
            }
            return vegeVan;
        }
        static void zombikLeptetese(Zombie[] zombik, Tower[] towerek,int szamlalo)
        {
            //lepnek a zombiek, csokken a cooldown
            for (int i = 0; i < szamlalo; i++)
            {
                zombik[i].lepes();
            }
            for (int i = 0; i < towerek.Length; i++)
            {
                if (towerek[i].cooldown>0)
                {
                    towerek[i].cooldown--;
                }
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
