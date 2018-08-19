using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_5我要做月老_二分圖最大匹配
{
    static class es
    {
        static public int ToInt(this string str)
        {
             return int.Parse(str);
        }
    }
    class Program
    {
        static int[,] e;
        static int[] match;
        static int[] book;
        static void Main(string[] args)
        {
            string[] tempStr;
            tempStr = Console.ReadLine().Split(' ');
            e = new int[tempStr[0].ToInt()+ 1, tempStr[0].ToInt() + 1];
            match = new int[e.GetLength(0)];
            book = new int[match.Length];
            int tempInt = tempStr[1].ToInt();
            for(int i = 0; i <tempInt;i++)
            {
                tempStr = Console.ReadLine().Split(' ');
                e[tempStr[0].ToInt(), tempStr[1].ToInt()] = 1;
                e[ tempStr[1].ToInt(),tempStr[0].ToInt()] = 1;
            }
            int sum = 0;
           
            for (int i = 1; i < match.Length; i++)
            {
                for (int j = 1; j < match.Length; j++)
                    book[j] = 0;
                if (dfs(i))
                    sum++;
            }
            Console.WriteLine(sum.ToString());
            Console.ReadLine();
               
        }
        static bool dfs(int u)
        {
            for(int i =1; i<match.Length;i++)
            {
                if(book[i]==0 && e[u,i] ==1)
                {
                    book[i] = 1;
                    if(match[i] == 0 || dfs(match[i]))
                    {
                        match[i] = u;
                        match[u] = i;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
