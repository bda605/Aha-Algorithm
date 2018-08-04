using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2城市地圖_圖的深度優先走訪
{
    class Map
    {
        public int Start;
        public int End;
        public int Path;
        public int book = 0;
        public Map(int Start, int End, int Path)
        {
            this.Start = Start;
            this.End = End;
            this.Path = Path;
        }
    }
    class Program
    {
        static List<Map> map = new List<Map>();
        static int min = 99999;
        static int sum = 0;
        static void dfs(int num)
        {

            if (num == 5)
            {
                if (min > sum)
                {
                    min = sum;

                }
                return;
            }
            map.Where(x => x.Start == num).ToList().ForEach(y =>
            {
                if (y.book == 0)
                {
                    y.book = 1;
                    sum += y.Path;
                    dfs(y.End);
                    sum -= y.Path;
                    y.book = 0;
                }
            });
        }
        static void Main(string[] args)
        {
            Console.Write("請輸入道路個數：");
            int road = int.Parse(Console.ReadLine());
            string[] temp;
            for (int i = 0; i < road; i++)
            {
                temp = Console.ReadLine().Split(' ');
                map.Add(new Map(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2])));
            }
            dfs(1);
            Console.WriteLine("最短路徑長：" + min);

            Console.Read();
        }
    }
}
