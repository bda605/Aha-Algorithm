using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_4擒賊先擒王_並查集
{
    static class ExtensionString
    {
        static public int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
    class Program
    {
        static int[] thief;
        static int getThief(int i)
        {
            if(thief[i] ==i)
            {
                return i;
            }
            else
            {
                thief[i] = getThief(thief[i]);
                return thief[i];
            }
        }
        static void  merge(int x,int y)
        {
            int t1 = getThief(x), t2 = getThief(y);
            if (t1 != t2)
                thief[t2] = t1;
        }
        static void Main(string[] args)
        {
            Console.Write("請輸入有幾個盜賊：");
            int thiefCount = Console.ReadLine().ToInt();
            thief = new int[thiefCount+1];
            for (int i = 0; i < thief.Length; i++)
                thief[i] = i;            
            Console.Write("請輸入有幾條線索：");
            int clueCount = Console.ReadLine().ToInt();
            string[] t;
            for(int i =0; i < clueCount;i++)
            {
                t = Console.ReadLine().Split(' ');
                merge(t[0].ToInt(), t[1].ToInt());
            }
            int sum = 0;
            for (int i = 1; i < thief.Length; i++)
                if (thief[i] == i)
                    sum++;
            Console.WriteLine($"共有 {sum} 個盜賊集團");
            Console.Read();
        }
    }
}
