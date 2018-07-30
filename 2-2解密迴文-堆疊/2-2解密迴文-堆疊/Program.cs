using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2解密迴文_堆疊
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5/2 =2 0-2 2-4
            // 6/2 =3 0-3-1 3-5
            Console.WriteLine("請輸入一個字串");
            char[] s = Console.ReadLine().ToArray();
            Stack<char> stack = new Stack<char>();
            int mid=s.Length;
            if (mid % 2 == 0)
                mid = mid / 2 - 1;
            else
                mid = mid / 2;
            for (int i = 0; i <= mid; i++)
                    stack.Push(s[i]);            
            for (int i = mid; i < s.Length; i++)
            {
                if (stack.Peek() != s[i])
                    break;
                else
                    stack.Pop();
            }
            if(stack.Count == 0 )
                Console.WriteLine("此字串 是 一個迴文字串");
            else
                Console.WriteLine("此字串 不是 一個迴文字串");         
            Console.Read();
        }
    }
}
