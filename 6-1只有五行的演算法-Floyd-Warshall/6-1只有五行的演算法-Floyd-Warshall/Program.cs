using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_1只有五行的演算法_Floyd_Warshall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入有幾個城市：");
            int city = int.Parse(Console.ReadLine())+1;
            Console.Write("請輸入有幾條道路：");
            int road = int.Parse(Console.ReadLine());
            int inf = 1000000000;
            int[,] path = new int[city, city];
            for (int i = 0; i < city; i++)
                for (int j = 0; j < city; j++)
                    if (i == j)
                        path[i, j] = 0;
                    else
                        path[i, j] = inf;
            int[] temp;
            for (int i= 0; i< road;i++)
            {
                temp=Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>( x=>int.Parse(x))).ToArray();
                path[temp[0], temp[1]] = temp[2];
            }
            for (int k = 1; k < city; k++)
                for (int i = 1; i < city; i++)
                    for (int j = 1; j < city; j++)
                        if (path[i, k] < inf && path[k,j] < inf && path[i, j] > path[i, k] + path[k, j])
                            path[i, j] = path[i, k] + path[k, j];
            for (int i = 1; i < city; i++)
                for (int j = 1; j < city; j++)
                    if (i != j)
                        Console.WriteLine($"{i} 到 {j} 的最短路徑長為 {path[i, j]}");

            Console.Read();
        }
    }
}
