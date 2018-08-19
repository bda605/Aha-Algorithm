using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_3堆積_神奇的優先佇列
{
    class Program
    {
        static void siftdown(int i )
        {
            int temp = i;
            bool flag = false;  
            while (i * 2 <= length && flag ==false)
            {
               if( tree[i] > tree[i*2])                
                    temp = i*2;
                if (i * 2 + 1 <= length)
                {
                    if (tree[temp] > tree[i * 2 + 1])
                        temp = i * 2 + 1;
                }
                
                if(temp != i)
                {
                    swap(i, temp);
                    i = temp;                    
                }
                else
                {
                    flag = true;
                }
            }
        }
        static void swap(int i,int j)
        {
            int temp = tree[i];
            tree[i] = tree[j];
            tree[j] = temp;
        }
        static int delMax()
        {
            int temp = tree[1];
            tree[1] = tree[length];
            length--;
            siftdown(1);
            return temp;
        }
        static int[] tree;
        static int length;
        static void Main(string[] args)
        {
            length = int.Parse(Console.ReadLine()) ;
            tree = new int[length+1];
            string[] temp = Console.ReadLine().Split(' ');
            for(int i = 0; i< temp.Length;i++)
                tree[i+1]= int.Parse(temp[i]);
            for(int i = (tree.Length-1)/2; i >=1; i--)
            {
                siftdown(i);
            }
            int num = length;
            

            Console.WriteLine("----------結果----------");
            Console.WriteLine("堆積");
            Console.WriteLine(string.Join(" ",tree.SkipWhile((x, y) => y == 0).ToList().ConvertAll(new Converter<int, string>(x => x.ToString())) ));
            Console.WriteLine("由小排到大");
            for (int i = 1; i <= num; i++)
                Console.Write(delMax() + " ");
            Console.ReadLine();
            
        }
    }
}
