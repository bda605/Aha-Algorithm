using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _6_3Bellman_Ford__解決負權邊
{
    class Path
    {
        public int Start;
        public int End;
        public int PathLength;
      /*  public Path(int Start,int End,int PathLength)
        {
            this.Start = Start;
            this.End = End;
            this.PathLength = PathLength;
        }*/

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => int.Parse(x))).ToArray();
            int Vertex = temp[0];
            Path[] p = new Path[temp[1]+1];
            for(int i = 1; i < p.Length;i++)
            {
                temp= Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => int.Parse(x))).ToArray();
                p[i] = new Path();
                p[i].Start = temp[0];
                p[i].End = temp[1];
                p[i].PathLength = temp[2];
            }
            int[] distance = new int[Vertex+1];
            distance[1] = 0;
            int inf = 1000000000;
            for (int i = 2; i < distance.Length; i++)
                distance[i] = inf;
            Stopwatch time = new Stopwatch();
            
            int[] flag=new int[distance.Length];
            time.Start();
            for (int k = 1; k < Vertex - 1; k++)
            {
                //distance.CopyTo(flag, 0);
                for (int i = 1; i < p.Length; i++)
                    if (distance[p[i].End] > distance[p[i].Start] + p[i].PathLength)
                        distance[p[i].End] = distance[p[i].Start] + p[i].PathLength;
                //if (flag == distance) break;
            }
            time.Stop();
            Console.WriteLine(string.Join(" ", distance.SkipWhile((x, y) => y == 0).ToList().ConvertAll(new Converter<int, string>(x => x.ToString())).ToArray() ));
            Console.WriteLine($"耗時：{time.Elapsed}");
            Console.Read();
        }
    }
}
