using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_4再解炸彈人
{
    class point
    {
        public int x;
        public int y;
        public int kill;
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("你現在有一個炸彈，可以放在如下的地圖");
            Console.WriteLine("試問如何才能炸死最多敵人");
            Console.WriteLine("註: # 為牆壁  E 為敵人  . 為 空地");
            Console.WriteLine("註: 玩家所在座標為 ( 3 , 3 )");
            string[,] map = new string[,]
            {
                { "#","#","#","#","#","#","#","#","#","#","#","#","#"},
                { "#","E","E",".","E","E","E","#","E","E","E",".","#"},
                { "#","#","#",".","#","E","#","E","#","E","#","E","#"},
                { "#",".",".",".",".",".",".",".","#",".",".","E","#"},
                { "#","E","#",".","#","#","#",".","#","E","#","E","#"},
                { "#","E","E",".","E","E","E",".","#",".","E","E","#"},
                { "#","E","#",".","#","E","#",".","#",".","#",".","#"},
                { "#","#","E",".",".",".","E",".",".",".",".",".","#"},
                { "#","E","#",".","#","E","#","#","#",".","#","E","#"},
                { "#",".",".",".","E","#","E","E","E",".","E","E","#"},
                { "#","E","#",".","#","E","#","E","#",".","#","E","#"},
                { "#","E","E",".","E","E","E","#","E",".","E","E","#"},
                { "#","#","#","#","#","#","#","#","#","#","#","#","#"}
            };
            for (int i = 0; i <= map.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= map.GetUpperBound(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            int[,] book = new int[13, 13];
            int[,] next = new int[4, 2]
            {
                { 0,1},
                { 1,0},
                { 0,-1},
                { -1,0}
            };
            Queue<point> p = new Queue<point>();
            p.Enqueue(new point(3, 3));
            int tx, ty;
            while (p.Count > 0)
            {
                point point = p.Dequeue();
                for (int i = 0; i < next.GetLength(0); i++)
                {
                    tx = point.x + next[i, 0];
                    ty = point.y + next[i, 1];
                    if (tx < 0 | ty < 0 | tx > map.GetUpperBound(0) | ty > map.GetUpperBound(1))
                        continue;
                    if (map[tx, ty] == "." && book[tx, ty] == 0)
                    {
                        book[tx, ty] = 1;
                        p.Enqueue(new point(tx, ty));
                    }
                }
            }
            for (int i = 0; i < book.GetLength(0); i++)
            {
                for (int j = 0; j < book.GetLength(1); j++)
                {
                    Console.Write(book[i, j] + " ");
                }
                Console.Write("\n");
            }

            List<point> temp = new List<point>();
            for (int i = 0; i < book.GetLength(0); i++)
            {
                for (int j = 0; j < book.GetLength(1); j++)
                {
                    if (i == 9 && j == 9)
                        Console.Write("");
                    if (book[i, j] == 1)
                    {
                        temp.Add(new point(i, j));
                        tx = i;
                        ty = j;
                        while (ty < book.GetLength(1))
                        {
                            ty++;
                            if (map[tx, ty] == "E")
                                temp.Last().kill++;
                            if (map[tx, ty] == "#")
                                break;
                        }
                        tx = i;
                        ty = j;
                        while (ty > -1)
                        {
                            ty--;
                            if (map[tx, ty] == "E")
                                temp.Last().kill++;
                            if (map[tx, ty] == "#")
                                break;
                        }
                        tx = i;
                        ty = j;
                        while (tx < book.GetLength(0))
                        {
                            tx++;
                            if (map[tx, ty] == "E")
                                temp.Last().kill++;
                            if (map[tx, ty] == "#")
                                break;
                        }
                        tx = i;
                        ty = j;
                        while (tx > -1)
                        {
                            tx--;
                            if (map[tx, ty] == "E")
                                temp.Last().kill++;
                            if (map[tx, ty] == "#")
                                break;
                        }
                    }
                }

            }
            point max = temp.Find(x => x.kill == temp.Max(y => y.kill));
            Console.WriteLine($"需要將炸彈放置在 ( {max.x} , {max.y} ) , 可以炸死 {max.kill} 個敵人");

            Console.Read();
        }
    }
}

