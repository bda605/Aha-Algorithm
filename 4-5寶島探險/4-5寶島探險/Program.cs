using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_5寶島探險
{
    class point
    {
        public int x;
        public int y;
        public point(int x,int y  )
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("地圖大小為 10 x 10");
            Console.WriteLine("小亨 降落座標為 ( 5 , 7 )");
            Console.WriteLine("地圖如下 註: 0為海洋 1為陸地");
            Console.WriteLine("求小亨腳下的島嶼面積為多少");
            int[,] map = new int[10, 10]
            {
                { 1,2,1,0,0,0,0,0,2,3},
                { 3,0,2,0,1,2,1,0,1,2},
                { 4,0,1,0,1,2,3,2,0,1},
                { 3,2,0,0,0,1,2,4,0,0},
                { 0,0,0,0,0,0,1,5,3,0},
                { 0,1,2,1,0,1,5,4,3,0},
                { 0,1,2,3,1,3,6,2,1,0},
                { 0,0,3,4,8,9,7,5,0,0},
                { 0,0,0,3,7,8,6,0,1,2},
                { 0,0,0,0,0,0,0,0,1,0}
            };
            for (int i = 0; i < map.GetLength(0); i++)
            {       for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.Write("\n");
            }
            int[,] book = new int[10, 10];
            int[,] next = new int[4, 2]
            {
                {0,1 },
                {1,0 },
                {0,-1},
                {-1,0}
            };
            int tx, ty = 0;
            Queue<point> bfs = new Queue<point>();
            //求面積
            bfs.Enqueue(new point(5, 7));
            while (bfs.Count > 0)
            {
                point p = bfs.Dequeue();
                for (int i = 0; i < next.GetLength(0); i++)
                {
                    tx = p.x + next[i, 0];
                    ty = p.y + next[i, 1];
                    if (tx < 0 | ty < 0 | tx > map.GetUpperBound(0) | ty > map.GetUpperBound(1))
                        continue;
                    if (book[tx, ty] == 0 && map[tx, ty] != 0)
                    {
                        book[tx, ty] = 1;
                        bfs.Enqueue(new point(tx, ty));
                    }
                }

            }
            int area = 0;
            for (int i = 0; i < book.GetLength(0); i++)
                for (int j = 0; j < book.GetLength(1); j++)
                    if (book[i, j] == 1)
                    {
                        area++;
                        book[i, j] = 0;
                    }
            //求島嶼個數
            Queue<point> temp = new Queue<point>();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    if (map[i, j] > 0)
                    {
                        temp.Enqueue(new point(i, j));
                        break;        
                    }
                if (temp.Count > 0)
                    break;
            }
            
            int island = 0;
            
            while(temp.Count>0)
            {
                bfs.Enqueue(temp.Dequeue());
                island--;
                while(bfs.Count>0)
                {
                    point p = bfs.Dequeue();
                    map[p.x, p.y] = island;
                    for (int i = 0; i < next.GetLength(0); i++)
                    {
                        tx = p.x + next[i, 0];
                        ty = p.y + next[i, 1];
                        if (tx < 0 | ty < 0 | tx > map.GetUpperBound(0) | ty > map.GetUpperBound(1))
                            continue;
                        if (book[tx, ty] == 0 && map[tx, ty] > 0)
                        {
                            book[tx, ty] = 1;
                            map[tx, ty] = island;
                            bfs.Enqueue(new point(tx, ty));

                        }
                    }
                }
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                        if (map[i, j] > 0)
                        {
                            temp.Enqueue(new point(i, j));
                            break;
                        }
                    if (temp.Count > 0)
                        break;
                }
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].ToString().Length == 1)
                        Console.Write(" ");
                    Console.Write(map[i, j] + " ");
                        
                }
                Console.Write("\n");
            }
            Console.WriteLine($"面積為 : {area} ");
            Console.WriteLine($"共有 {Math.Abs(island)} 個 島嶼");

            Console.Read();
        }
    }
}
