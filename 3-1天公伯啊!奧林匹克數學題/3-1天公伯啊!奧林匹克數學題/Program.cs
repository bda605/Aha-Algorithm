using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1天公伯啊_奧林匹克數學題
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("題目：□□□ ＋ □□□ ＝ □□□");
            Console.WriteLine("請將 1 ~ 9 分別填入 □ 中來完成此等式");
            Console.WriteLine("試問有幾種組合");
            int[] book = new int[11];
            int[] a = new int[10];
            int ans=0;      
            for( a[1]=1; a[1] <= 9; a[1]++)
                for (a[2] = 1; a[2] <= 9; a[2]++)
                    for (a[3] = 1; a[3] <= 9; a[3]++)
                        for (a[4] = 1; a[4] <= 9; a[4]++)
                            for (a[5] = 1; a[5] <= 9; a[5]++)
                                for (a[6] = 1; a[6] <= 9; a[6]++)
                                    for (a[7] = 1; a[7] <= 9; a[7]++)
                                        for (a[8] = 1; a[8] <= 9; a[8]++)
                                            for (a[9] = 1; a[9] <= 9; a[9]++)
                                            {
                                                for (int i = 1; i <= 9; i++)
                                                    book[i] = 0;
                                                for (int i = 1; i < a.Length; i++)
                                                    book[a[i]]++;
                                                if (book.Count(i => i == 1) == 9)
                                                    if ((a[1] * 100 + a[2] * 10 + a[3] + a[4] * 100 + a[5] * 10 + a[6]) == (a[7] * 100 + a[8] * 10 + a[9]))
                                                    {
                                                        ans++;
                                                        Console.WriteLine($"{a[1]}{a[2]}{a[3]} + {a[4]}{a[5]}{a[6]} = {a[7]}{a[8]}{a[9]}");
                                                    }
                                            }
                                                
            Console.WriteLine($"Ans : {ans/2} 種");
            Console.Read();
        }
    }
}
