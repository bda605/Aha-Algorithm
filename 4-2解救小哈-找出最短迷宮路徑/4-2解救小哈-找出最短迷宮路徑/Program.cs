using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2解救小哈_找出最短迷宮路徑
{


    class Program
    {
        static int[,] map = new int[5, 4]{
                    {0,0,1,0 },
                    {0,0,0,0 },
                    {0,0,1,0 },
                    {0,1,0,0 },
                    {0,0,0,1 },
                };
        static int[,] next = new int[4, 2]
        {
            //上下左右
            {-1,0 },
            {1,0  },
            {0,-1 },
            {0,1  },
        };
        static int min = 99999;
        static int maxX, maxY;
   
        static int[,] book = new int[5,4];
        static void dfs( int x, int y, int step)
            {
            int tx, ty;
            if(x == 3 && y == 2)
            {
                if (min > step)
                    min = step; ;
                return;
            }
            for(int i = 0; i < next.GetLength(0); i++)
            {
                tx = x + next[i,0];
                ty = y + next[i, 1];
                if (tx < 0 | ty < 0 | tx > maxX | ty > maxY)
                    continue;
                if( book[tx,ty] == 0 && map[tx,ty] == 0)
                {
                    book[tx, ty] = 1;
                    dfs(tx, ty, step+1);
                    book[tx, ty] = 0;
                }
            }

        }
        static void Main(string[] args)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("迷宮入口座標為 ( 0 , 0 )");
            Console.WriteLine("小哈所在座標為 ( 3 , 2 )");
            Console.WriteLine("試問最少須走幾格才會到達小哈所在位置");
            maxX = 4;
            maxY = 3;
            book[0, 0] = 1;
            dfs(0, 0, 0);
            Console.WriteLine($"Ans : {min} 格");
            Console.Read();
        }
    }
}

