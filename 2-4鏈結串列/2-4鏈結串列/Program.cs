using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4鏈結串列
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入排列好的的數字(數字請用空格隔開)");
            LinkedList<int> link = new LinkedList<int>();
            foreach(var s in Console.ReadLine().Split(' '))
            {
                link.AddLast(int.Parse(s));
            }
            Console.WriteLine("請輸入要插入的數字");
            int insert = int.Parse(Console.ReadLine());
            Console.WriteLine("插入後的數列");
            if(link.ElementAt(0) > link.ElementAt(1))
            {//大到小排列
                if (insert > link.ElementAt(0))
                    link.AddFirst(insert);
                for(int i = 0; i<link.Count-1;i++)
                {
                    if (link.ElementAt(i) > insert && link.ElementAt(i + 1) < insert)
                        link.AddAfter(link.Find(link.ElementAt(i)),insert);
                }
                if (insert < link.ElementAt(link.Count-1))
                    link.AddLast(insert);
            }
            else
            {//小到大排列
                if (insert > link.ElementAt(link.Count-1))
                    link.AddLast(insert);
                for (int i = link.Count-1 ; i > 0; i--)
                {
                    if (link.ElementAt(i) > insert && link.ElementAt(i - 1) < insert)
                        link.AddBefore(link.Find(link.ElementAt(i)), insert);
                }
                if (insert < link.ElementAt(0))
                    link.AddFirst(insert);
            }
            foreach(var i in link)
            {
                Console.Write(i + " ");
            }

            Console.Read();
        }
    }
}
