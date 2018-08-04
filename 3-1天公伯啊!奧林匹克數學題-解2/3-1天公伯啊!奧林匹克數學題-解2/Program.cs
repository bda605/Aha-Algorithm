using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _3_1天公伯啊_奧林匹克數學題_解2
{
    class Program
    {
        static void dfs(int step)
        {
            if (step ==10 &&
                (square[1]+square[4]) *100 + (square[2]+square[5])*10 + square[3]+square[6] == square[7]*100 + square[8]*10 +square[9])
            {
                Console.WriteLine($"{square[1]}{square[2]}{square[3]} + {square[4]}{square[5]}{square[6]} = {square[7]}{square[8]}{square[9]}");
                ans++;
                return;
            }
            for (int i = 1; i <= 9; i++)
            {
                if(book[i] == 0)
                {
                    square[step] = i;
                    book[i] = 1;
                    dfs(step + 1);
                    book[i] = 0;
                    square[step] = 0;
                }
            }
        }
        static int ans;
        static int[] book, square;
        static void Main(string[] args)
        {
            Console.WriteLine("請將數字 1 ~ 9 填入以下的 □ 中以完成等式");
            Console.WriteLine(" □ □ □ + □ □ □ = □ □ □");
            book = new int[10];
            square = new int[10];
            Stopwatch time = new Stopwatch();
            time.Start();
            dfs(1);
            time.Stop();
            Console.WriteLine($"Ans : {ans/2} 組 解");            
            Console.WriteLine($"耗時： {time.Elapsed}");
            Console.Read();
        }
    }
}
