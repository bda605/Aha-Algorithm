using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _6_4Bellman_Ford的佇列優化
{
    class Path
    {
        public int Start;
        public int End;
        public int PathLength;
       

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => int.Parse(x))).ToArray();
            int Vertex = temp[0];
            Path[] p = new Path[temp[1] + 1];
            p[0] = new Path();
            for (int i = 1; i < p.Length; i++)
            {
                temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => int.Parse(x))).ToArray();
                p[i] = new Path();
                p[i].Start = temp[0];
                p[i].End = temp[1];
                p[i].PathLength = temp[2];
            }
            int[] distance = new int[Vertex + 1];
            int[] book = new int[distance.Length];
            distance[1] = 0;
            int inf = 1000000000;
            for (int i = 2; i < distance.Length; i++)
                distance[i] = inf;
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            book[1] = 1;
            Stopwatch time = new Stopwatch();
            time.Start();
            
            while(q.Count>0)
            {
                int val = q.Dequeue();
                p.Where(x => x.Start == val).ToList().ForEach(x =>
                {
                    if (distance[x.End] > distance[x.Start] + x.PathLength)
                    {
                        distance[x.End] = distance[x.Start] + x.PathLength;
                        if (book[x.End] == 0)
                        {
                            book[x.End] = 1;
                            q.Enqueue(x.End);

                        }
                    }
                });               
            }
            time.Stop();
            Console.WriteLine("頂點 1 到 各頂點路徑長：" + string.Join(" ", distance.SkipWhile((x, y) => y == 0).ToList().ConvertAll(new Converter<int, string>(x=>x.ToString())).ToArray()));
            Console.WriteLine($"耗時：{time.Elapsed}");
            Console.Read();
        }
    }
}
