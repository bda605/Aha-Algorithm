using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_6水管工遊戲
{
    class point
    {
        public int x;
        public int y;
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static List<point> p = new List<point>();
        static bool goal = false;
        static void dfs(int x , int y, int path )
        {
            // path 說明
            // 當數值 = 1 時 , 進水口在 右邊
            // 當數值 = 2 時 , 進水口在 下邊
            // 當數值 = 3 時 , 進水口在 左邊
            // 當數值 = 4 時 , 進水口在 上邊
            if (x == map.GetUpperBound(0) && y == map.GetUpperBound(1) + 1)
            {
                Console.Write("Ans : ");
                p.ForEach(listP => Console.Write($"({listP.x} , {listP.y})  "));
                goal = true;
                return;
            }
            if (x < 0 | y < 0 | x > map.GetUpperBound(0) | y > map.GetUpperBound(1))
                return;
            if (book[x, y] == 1)
                return;
            
           int tube = map[x, y];
           book[x, y] = 1;
            p.Add(new point(x, y));
           if(tube >0 && tube < 5)
            {
                if (path == 1)
                {
                    dfs(x-1, y , 2);
                    dfs(x+1, y, 4);
                }
                else if (path == 2)
                {
                    dfs(x , y+1, 3);
                    dfs(x , y-1, 1);
                }
                else if (path == 3)
                {
                    dfs(x - 1, y, 2);
                    dfs(x + 1, y, 4);
                }
                else if (path == 4)
                {
                    dfs(x, y + 1, 3);
                    dfs(x, y - 1, 1);
                }
            }
           else if(tube >4 )
            {
                if (path == 1)
                {
                    dfs(x, y - 1, 1);
                }
                else if (path == 2)
                {
                    dfs(x - 1, y, 2);
                }
                else if (path == 3)
                {
                    dfs(x, y +1, 3);
                }
                else if (path == 4)
                {
                    dfs(x + 1, y, 4);
                }
            }
            p.Remove(p.Last());
            book[x, y] = 0;
        }
        static int[,] book = new int[5, 4];
        static int[,] next = new int[4,2]
        {
            {0, 1},
            {1,0},
            {0,-1 },
            {-1,0 }
        };
        static int[,] map = new int[5, 4]
            {
                { 5,3,5,3},
                { 1,5,3,0},
                { 2,3,5,1},
                { 6,1,1,5 },
                {1,5,5,1 }
            };
        static void Main(string[] args)
        {
            
            Console.WriteLine("代號說明:");
            Console.WriteLine(" 0 ->  障礙物");
            Console.WriteLine(" 1 -> └");
            Console.WriteLine(" 2 -> ┌");
            Console.WriteLine(" 3 ->  ┐");
            Console.WriteLine(" 4 ->  ┘");
            Console.WriteLine(" 5 ->  ─");
            Console.WriteLine(" 6 -> │");
            Console.WriteLine("------------------------");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    Console.Write(map[i, j] + " ");
                Console.Write("\n");
            }
            Console.WriteLine("求路徑解");
            dfs(0, 0,3);
            if (!goal)
                Console.WriteLine("Impossible ! 無解");
            Console.Read();
        }
    }
}
