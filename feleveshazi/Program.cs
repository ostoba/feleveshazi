using System;
using System.Linq;
using System.Threading;

namespace feleveshazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map = mapLetrehozas();
            Tower[] towerek = new Tower[5];
            Zombie[] zombik = zombieLetrehozas(50);
            int[] zombikhelyei = new int[zombik.Length];
            Jatek(zombik, map, towerek, zombikhelyei);
            Console.ReadLine();
        }
        static void Jatek(Zombie[] zombik, Map map, Tower[] towerek, int[] zombikhelyei)
        {
            map.MapKiiratas();
            towerek = towerLetrehozas(map);
            zombieKiiratas(zombik);
            int zombieszamlalo = 0;
            while (!jatekVege(zombik, map))
            {
                towerLoves(towerek, zombik);
                Console.Clear();
                zombikLeptetese(zombik, towerek, zombieszamlalo, zombikhelyei);
                if (zombieszamlalo != zombik.Length)
                {
                    zombieszamlalo++;
                }
                zombieKiiratas(zombik);
                map.MapKiiratas();
                Console.WriteLine();
                #region ellenorzesek
                //for (int i = 0; i < towerek.Length; i++)
                //{
                //    Console.WriteLine("tower cd {0} indexe {1} range {2} minrange {3} maxrange {4}", towerek[i].cooldown, towerek[i].j, towerek[i].range, towerek[i].minRange, towerek[i].maxRange);
                //}
                //for (int i = 0; i < zombik.Length; i++)
                //{
                //    Console.WriteLine("zombi hol jar {0}, hanyadik zombie {1}", zombik[i].index, i);
                //}
                #endregion ellenorzesek
                towerKiiratas(towerek);
                Thread.Sleep(500);
            }
            if (jatekVege(zombik, map))
            {
                jatekVege(zombik, map);
            }
        }
        static Tower[] towerLetrehozas(Map map)
        {
            Random r = new Random();
            #region randomhelyreletrehozas
            //Random r = new Random();
            //int[] helyek = new int[5] { -1, -1, -1, -1, -1 };
            //for (int i = 0; i < towerek.Length; i++)
            //{
            //    towerek[i] = new Tower(r, helyek, map);
            //    helyek[i] = towerek[i].j;
            //    //Console.WriteLine("helyek {0} tower.j {1}", helyek[i], towerek[i].j);
            //}
            #endregion 
            Tower[] towerek = new Tower[5];
            int[] helyek = new int[5] { -1, -1, -1, -1, -1 };
            int[] leraktaMar = new int[5] { -1, -1, -1, -1, -1 };
            int szamlalo = 0;
            int sor = szamlalo + 9;
            Console.WriteLine();
            Console.WriteLine("Kerem adja meg hogy hanyadik tornyot hova rakjuk le! Minta : 1 40 , Elso torony 40. helyre.");
            Console.WriteLine("Ot torony van, 50. az utolso hely!");
            while (towerek.Length > szamlalo)
            {
                Console.SetCursorPosition(0, sor);
                sor++;
                //input = 1 40 , elso tower 40edik hely, towerek[1-1] 40-1es index
                string[] input = Console.ReadLine().Split(' ');
                int hanyadik = int.Parse(input[0]) - 1;
                int hova = int.Parse(input[1]) - 1;
                while (helyek.Contains(hova))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ezen a helyen mar van torony, probald ujra!");
                    Thread.Sleep(1500);
                    sorTorles();
                    Console.ResetColor();
                    input = Console.ReadLine().Split(' ');
                    hanyadik = int.Parse(input[0]) - 1;
                    hova = int.Parse(input[1]) - 1;
                    sor++;
                }
                while (leraktaMar.Contains(hanyadik))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ezt a tornyot mar leraktad, probald ujra!");
                    Thread.Sleep(1500);
                    sorTorles();
                    Console.ResetColor();
                    input = Console.ReadLine().Split(' ');
                    hanyadik = int.Parse(input[0]) - 1;
                    hova = int.Parse(input[1]) - 1;
                    sor++;
                }
                towerek[hanyadik] = new Tower(r, map, hova);
                towerek[hanyadik].towerKiiratas();
                helyek[szamlalo] = hova;
                leraktaMar[szamlalo] = hanyadik;
                szamlalo++;
            }
            return towerek;
        }
        static void towerKiiratas(Tower[] towerek)
        {
            Random r = new Random();
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i].towerKiiratas();
            }
        }
        static Map mapLetrehozas()
        {
            Map map = new Map(50);
            return map;
        }
        static Zombie[] zombieLetrehozas(int mennyiZombie)
        {
            Zombie[] zombik = new Zombie[mennyiZombie];
            for (int i = 0; i < zombik.Length; i++)
            {
                zombik[i] = new Zombie();
            }
            return zombik;
        }

        static bool beErtEgyZombie(Zombie[] zombik, Map map)
        {
            bool beErt = false;
            for (int i = 0; i < zombik.Length; i++)
            {
                if (zombik[i].beErtE(map) == true)
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
            if (beErtEgyZombie(zombik, map))
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
        static void zombikLeptetese(Zombie[] zombik, Tower[] towerek, int szamlalo, int[] zombikhelyei)
        {
            //lepnek a zombiek, csokken a cooldown
            for (int i = 0; i < szamlalo; i++)
            {
                zombik[i].lepes();
                zombikhelyei[i] = zombik[i].index;
            }
            for (int i = 0; i < towerek.Length; i++)
            {
                if (towerek[i].cooldown > 0)
                {
                    towerek[i].cooldown--;
                }
            }

        }
        static void zombieKiiratas(Zombie[] zombik)
        {
            for (int i = 0; i < zombik.Length; i++)
            {
                zombik[i].zombieKiiratas();
            }
        }
        static void towerLoves(Tower[] towerek, Zombie[] zombik)
        {
            for (int i = 0; i < towerek.Length; i++)
            {
                towerek[i].loves(zombik);
            }
        }
        static void sorTorles()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}