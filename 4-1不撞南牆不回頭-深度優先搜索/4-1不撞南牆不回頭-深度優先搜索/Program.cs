using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1不撞南牆不回頭_深度優先搜索
{
    class Program
    {
        static void dfs(int step)
        {
            if(step == n+1)
            {
                for (int i = 1; i <= n ; i++)
                {
                    Console.Write(box[i]);
                }
                Console.Write("\n");
                
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                if(book[i] == 0)
                {
                    box[step] = i;
                    book[i] = 1;
                    dfs(step + 1);
                    box[step] = 0;
                    book[i] = 0;
                }
            }
        }
        static int n = 0;
        static int[] book = new int[10];
        static int[] box = new int[10];
        static void Main(string[] args)
        {
            Console.Write("輸出 1 ~ X 的全排列 , 其中 X = ");
             n = int.Parse(Console.ReadLine());
            dfs(1);
            Console.Read();
        }
    }
}
