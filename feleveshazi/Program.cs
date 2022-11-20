using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feleveshazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tower[] towerek = towerLetrehozas();
            Map map = mapLetrehozas();
            map.MapKiiratas();
            towerKiiratas(towerek);
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
                //Console.Write("i {0} j {1}", towerek[i].i, towerek[i].j);
                //Console.WriteLine();
                towerek[i].Kiiratas(r);
            }
        }
        static Map mapLetrehozas()
        {
            Map map = new Map();
            return map;
        }
        static void mapKiiratas(Map map)
        {
            map.MapKiiratas();
        }
    }
}
