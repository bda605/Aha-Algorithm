using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _3_3火柴棒等式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請用現有的火柴棒排出 □ + □ = □");
            Console.WriteLine(" + 和 = 分別需要兩根火柴棒");
            Console.Write("現在你有 X (X <= 24) 根 火柴棒 試問可以排出幾種組合 X = ");
            Stopwatch time = new Stopwatch();
           
            int root = int.Parse(Console.ReadLine());
            time.Start();
            int c,ans = 0;
            for (int i = 0; i <= 1111; i++)
            {
                for (int j = 0; j <= 1111; j++)
                {
                    c = i + j;
                    if((getRoot(i)+getRoot(j)+getRoot(c)) == root -4)
                    {
                        ans++;
                    }
                }
            }
            time.Stop();
            Console.WriteLine($"Ans : {ans} 種 組合");
            Console.WriteLine($"耗時 {time.Elapsed} 秒");
            Console.Read();
        }
        static int getRoot(int num)
        {
            int total = 0;
            int[] root = new int[] { 6,2,5,5,4,5,6,3,7,6};
            // 時間複雜度較高
            //string num2 = num.ToString();
            // for (int i = 0; i < num2.Length; i++)
            //      total += root[int.Parse(num2.Substring(i, 1))];

            // 時間複雜度較低
            while (num / 10 != 0)
            {
                total += root[num % 10];
                num /= 10;
            }
            total += root[num];
            return total;
        }
    }
}
