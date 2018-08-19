using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_1鏢局運鏢_圖的最小生成樹
{
    static class ExtenstionString
    {
         static public int ToInt(this string str)
        {
        return int.Parse(str);
        }
    }
    class Path
    {
        public int s;
        public int e;
        public int l;
    }
    
    class Program
    {
        static Path[] p;
        static void quickSort(int left,int right)
        {
            int i, j;
            if (left > right)
                return;
            Path temp;
           i = left;
            j = right;
            while (j != i)
            {
                while (p[j].l >= p[left].l && j > i)
                    j--;
                while (p[i].l <= p[left].l && j > i)
                    i++;
                if(j>i)
                {
                    temp = p[i];
                    p[i] = p[j];
                    p[j] = temp;
                }

            }
            temp = p[left];
            p[left] = p[i];
            p[i] = temp;
            quickSort(left, i - 1);
            quickSort(i + 1, right);
        }
        static int getf(int v)
        {
            if( city[v] ==v)
            {
                return v;
            }
            else
            {
                city[v] = getf(city[v]);
                return city[v];
            }
        }
        static bool merge(int x ,int y)
        {
            x = getf(x);
            y = getf(y);
            if(x!= y)
            {
                city[y] = x;
                return true;
            }
            return false;
        }
        static int[] city;
        static void Main(string[] args)
        {
            Console.Write("請輸入有幾個城市：");
            city = new int[Console.ReadLine().ToInt()+1];
            for (int i = 0; i < city.Length; i++)
                city[i] = i;
            Console.Write("請輸入有幾條道路：");
            p = new Path[Console.ReadLine().ToInt()+1];
            int[] temp;
            for(int i = 1; i< p.Length;i++)
            {
                temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => x.ToInt())).ToArray();
                p[i] = new Path();
                p[i].s = temp[0];
                p[i].e = temp[1];
                p[i].l = temp[2];
            }
            quickSort(1, p.Length - 1);
            int edgeLength=0,edgeCount = 0;
            for(int i = 1; i< p.Length;i++)
            {
                if(merge(p[i].s,p[i].e))
                {
                    edgeCount++;
                    edgeLength += p[i].l;
                }
                if (edgeCount == city.GetUpperBound(0)-1)
                    break;
            }
            Console.WriteLine($"A n s：最短路徑為 {edgeLength}");
            Console.Read();
        }
    }
}
