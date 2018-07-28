using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1最快最簡單的排序_桶子排序
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             時間複雜度為 O(M+N)
             */
            Console.WriteLine("輸入 0-100 數字(以逗號進行分隔) :");
            string[] s = Console.ReadLine().Split(',');     //讀入字串
            int[] book = new int[101];
            for (int i = 0; i < book.Length; i++)
                book[i] = 0;                                //將陣列預設為 0
            for (int i = 0;i<s.Length;i++)               //進行排序
            {
                book[int.Parse(s[i])]++;
            }
            Console.WriteLine("數字排序結果(由小至大)");
            for(int i = 0;i<book.Length;i++)                //列出排序結果
            {
                for (int j = 0; j < book[i]; j++)
                    Console.Write(i + " ");
            }
            Console.Read();
        }
    }
}
