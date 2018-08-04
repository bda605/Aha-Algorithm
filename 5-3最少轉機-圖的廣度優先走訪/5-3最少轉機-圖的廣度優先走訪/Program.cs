using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_3最少轉機_圖的廣度優先走訪
{
    class plane
    {
        public int Start;
        public int End;
        public int book=0;
        public plane(int Start,int End)
        {
            this.Start = Start;
            this.End = End;
        }
    }
class Program
    {
        static int end = 0;
        static List<plane> p = new List<plane>();
        static Queue<int> q = new Queue<int>();
        static List<Queue<int>> lq = new List<Queue<int>>();
        static bool goal;
        static void bfs(int start)
        {
            
            if(start == end)
            {
                goal = true;
                q.Clear();
                return;
            }
            if (goal)
                return;
            p.Where(x => x.book == 0 ).ToList().ForEach(y => {
                if(y.Start == start)
                {
                    y.book = 1;
                    p.Find(z => z.Start == start && z.End == y.End).book = 1;
                    q.Enqueue(y.End);
                }
                else if(y.End==start)
                {
                    y.book = 1;
                    p.Find(z => z.End == start && z.Start == y.Start).book = 1;
                    q.Enqueue(y.Start);
                }
            });
            while(q.Count>0)
            {
                bfs(q.Dequeue());
            }
        }
        static void Main(string[] args)
        {
            int road = 0;
            Console.Write("請輸入起點城市編號：");
            int start = int.Parse(Console.ReadLine());
            Console.Write("請輸入終點城市編號：");
            end = int.Parse(Console.ReadLine());
            Console.Write("請輸入有幾條航線：");
            road = int.Parse(Console.ReadLine());
            string[] temp;
            for (int i = 0; i < road; i++)
            {
                temp = Console.ReadLine().Split(' ');
                p.Add(new plane(int.Parse(temp[0]), int.Parse(temp[1])));
                p.Add(new plane(int.Parse(temp[1]), int.Parse(temp[0])));
            }
            Queue<int> qlevel = new Queue<int>();
            Queue<int> qtemp = new Queue<int>();
            qlevel.Enqueue(start);
            lq.Add(qlevel);
            qlevel = new Queue<int>();
            //qlevel.Clear();
            bool goal = false;
            while (lq .Count>0)
            {
                qtemp = lq.Last();
                while (qtemp.Count > 0)
                {
                    int data = qtemp.Dequeue();
                    if (data == end)
                        goal = true;
                    p.ForEach(y => {
                        if (y.book == 0)
                        {
                            if (y.Start == data)
                            {
                                y.book = 1;
                                p.Find(z => z.End == data && z.Start == y.End).book = 1;
                                qlevel.Enqueue(y.End);
                            }
                            else if (y.End == data)
                            {
                                y.book = 1;
                                p.Find(z => z.Start == data && z.End == y.Start).book = 1;
                                qlevel.Enqueue(y.Start);
                            }
                        }
                    });
                }                
                if(goal | qlevel.Count == 0)
                    break;
                if (qlevel.Count > 0)
                {
                    lq.Add(qlevel);
                    qlevel = new Queue<int>();
                }
            }
            if (goal)
                Console.Write("最短路徑：" + (lq.Count - 1));
            else
                Console.WriteLine($"無法到達 城市 {end}");
            Console.Read();

        }
    }
}
