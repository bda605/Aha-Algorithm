using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3最常用的排序_快速排序
{ 
    class Program
    {
        static int[] num;
        static void quickSort(int left,int right)
        {
            if (left > right)
                return;
            int i = left;
            int j = right;
            int temp;
            int baseNum = num[i];
            while(i!=j)
            {
                while (num[i] <= baseNum && j > i)
                    i++;
                while (num[j] >= baseNum && j > i)
                    j--;
                
                if( j > i)
                {
                    temp = num[j];
                    num[j] = num[i];
                    num[i] = temp;
                }

            }
            temp = num[i];
            num[i] = num[left];
            num[left] = temp;
            quickSort(left, i - 1);
            quickSort(i + 1, right);


        }
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入數字(需以空格進行分隔)");                     
            string[] temp = Console.ReadLine().Split(' ');
            num = new int[temp.Length];
            for (int i = 0; i<temp.Length;i++)
            {
                num[i] = int.Parse(temp[i]);
            }
            quickSort(0, num.Length-1);

            Console.Write(String.Join(" ", num));
            Console.Read();
        }
    }
}
