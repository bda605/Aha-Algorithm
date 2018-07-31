using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_3層層遞進_廣度優先搜索
{
    class point
    {
        public int x;
        public int y;
        public int stepCount;
        public point(int x ,int y , int stepCount)
        {
            this.x = x;
            this.y = y;
            this.stepCount = stepCount;
        }
    }
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
            //右下左上
            {0,1 },
            {1,0  },
            {0,-1 },
            {-1, 0 },
        };
        static int[,] book = new int[5, 4];
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
            Queue<point> bfs = new Queue<point>();
            bfs.Enqueue(new point(0,0,0));
            bool goal = false;
            while(bfs.Count >0)
            {
                int tx, ty;
                point p = bfs.Dequeue();
                p.stepCount++;
                for (int i = 0; i < next.GetLength(0);i++)
                {

                    tx = p.x + next[i, 0];
                    ty = p.y + next[i, 1];                    
                    if (tx < 0 | ty < 0 | tx > map.GetUpperBound(0) | ty > map.GetUpperBound(1))
                        continue;
                    if( map[tx,ty] == 0 && book[tx,ty] == 0)
                    {
                        book[tx, ty] = 1;
                        bfs.Enqueue( new point(tx, ty,p.stepCount));
                        if(tx == 3 && ty ==2 )
                        {
                            goal = true;
                            break;
                        }
                    }
                }
                if (goal)
                    break;
            }
            
            Console.WriteLine($"Ans : {bfs.Last().stepCount} 格");
            Console.Read();
        }
    }
}
