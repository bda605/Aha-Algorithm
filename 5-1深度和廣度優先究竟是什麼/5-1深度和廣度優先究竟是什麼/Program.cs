using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_1深度和廣度優先究竟是什麼
{
    class link
    {
        public int start;
        public int end;
        public int book;
        public link(int start,int end)
        {
            this.book = 0;
            this.start = start;
            this.end = end;  
        }
    }
    class Program
    {

        static List<int> temp = new List<int>();
        static void dfs(int num)
        { 
            Queue<int> data = new Queue<int>();
       
            l.ForEach(x =>
            {
                if(x.book == 0)
                {
                    if(x.start == num )
                    {
                        x.book = 1;
                        l.Find(y => { return y.end == num && y.start == x.end; }).book = 1;
                        data.Enqueue(x.end);
                    }
                    else if(x.end ==num)
                    {
                        x.book = 1;
                        l.Find(y => { return y.start == num && y.end == x.start; }).book = 1;
                        data.Enqueue(x.start);
                    }
                }
            });
            if(!temp.Contains(num))
                temp.Add(num);
            while(data.Count>0)
            {
                if (l.Where(x => x.start == data.Peek() | x.end == data.Peek()).Where(y => y.book == 0).Count() > 0)
                    dfs(data.Dequeue());
                else
                {
                    if (!temp.Contains(data.Peek()))
                        temp.Add(data.Dequeue());
                    else
                        data.Dequeue();
                }                
            }
        }
        static List<link> l = new List<link>();
        static void Main(string[] args)
        {

            string[] read; 
            for(int i = 0; i <5;i ++)
            {
                read = Console.ReadLine().Split(' ');
                link lnk = new link(int.Parse(read[0]), int.Parse(read[1]) );
                l.Add(lnk);
                l.Add(new link(lnk.end, lnk.start));                
            }           
            dfs(1);
            temp.ForEach(x => Console.Write(x + " "));

            Console.Read();
        }
    }
}
