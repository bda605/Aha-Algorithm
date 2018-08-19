using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_2再談最小生成樹
{
    static class extensionString
    {
        static public int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
     class Path
    {
         public int Start;
         public int End;
         public int PathLength;
         public int Book;
    }
    class Program
    {
        static Path[] p;
        static void quickSort(int left,int right)
        {
            if (left  > right)
                return;
            int i = left, j = right;
            Path temp;
            while( i !=j)
            {
                while (p[j].PathLength >= p[left].PathLength && j > i)
                    j--;
                while (p[i].PathLength <= p[left].PathLength && j > i)
                    i++;
                if(j>i)
                {
                    temp = p[j];
                    p[j] = p[i];
                    p[i] = temp;
                }
            }
            temp = p[i];
            p[i] = p[left];
            p[left] = temp;
            quickSort(left, i - 1);
            quickSort(i + 1, right);
        }
        static void Main(string[] args)
        {
            Console.Write("請輸入城市數量：");
            int[] bookCity = new int[Console.ReadLine().ToInt()+1];
            for (int i = 0; i < bookCity.Length; i++)
                bookCity[i] = 0;
            Console.Write("請輸入路徑數量：");
            
            p = new Path[Console.ReadLine().ToInt() + 1];
            int[] temp;
            for(int i = 1; i < p.Length;i++)
            {
                p[i] = new Path();
                temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => x.ToInt())).ToArray();
                p[i].Start = temp[0];
                p[i].End = temp[1];
                p[i].PathLength = temp[2];
                p[i].Book = 0;
            }
            quickSort(1, p.Length - 1);
            bookCity[p[1].Start] = 1;
            bookCity[p[1].End] = 1;
            p[1].Book = 1;
            int pathCount = 0;
            int pathLength = 0;
            pathCount++;
            pathLength+= p[1].PathLength;
            while(pathCount < bookCity.GetUpperBound(0)-1)
            {
                for(int i =1; i <p.Length;i++)
                {
                    bool flag = false;
                    if (bookCity[p[i].Start] == 1 && bookCity[p[i].End] == 1 && p[i].Book == 0)
                        continue;
                    if(p[i].Book == 0 && bookCity[p[i].Start]==1  )
                    {
                        p[i].Book = 1;
                        bookCity[p[i].End] = 1;
                        pathCount++;
                        pathLength += p[i].PathLength;
                        flag = true;                        
                    }
                    else if(p[i].Book == 0 && bookCity[p[i].End] == 1)
                    {
                        p[i].Book = 1;
                        bookCity[p[i].Start] = 1;
                        pathCount++;
                        pathLength += p[i].PathLength;
                        flag = true;
                    }
                    if (flag)
                        break;
                }
            }
            Console.WriteLine($"A n s：最短路徑 {pathLength} ");
            Console.Read();

        }
    }
}
