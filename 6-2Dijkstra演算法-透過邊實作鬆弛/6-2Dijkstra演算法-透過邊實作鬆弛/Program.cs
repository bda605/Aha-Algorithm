using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2Dijkstra演算法_透過邊實作鬆弛
{
    public static class ExtensionString
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
    class Program
    {
      
        static void Main(string[] args)
        {
         
            Console.Write("請輸入頂點個數：");
            int v = Console.ReadLine().ToInt()+1;            
            Console.Write("請輸入邊的條數：");
            int side = Console.ReadLine().ToInt();
            int[,] map = new int[v, v];
            int inf = 100000000;
            int[] dis = new int[v];//存放 頂點1 到 各頂點的最短路徑長           
            int[] book = new int[v];//標記
            book[1] = 1;           
            dis[1] = 0;            
            //初始化 map 陣列
            for (int i = 1; i < v; i++)
                for (int j = 1; j < v; j++)
                    if (i == j) map[i, j] = 0;
                    else map[i, j] = inf;
            int[] temp;
            for(int i =0; i < side;i++)
            {
                temp = Console.ReadLine().Split(' ').ToList().ConvertAll(new Converter<string, int>(x => Convert.ToInt32(x) ) ).ToArray();
                map[temp[0], temp[1]] = temp[2];
            }
            //讀數值入dis
            for (int i = 2; i < v; i++)
                dis[i] = map[1, i];
            int min = 0;
            int tempVertex = 0;
            for (int i =1; i<v-1;i++)
            {                
                //判斷dis陣列哪個數值最小且未標記過
                //將其索引存入min中
                min = inf;
               for(int j =1; j< v;j++)
                {
                    if(book[j] == 0 && dis[j] < min)
                    {
                        min = dis[j];
                        tempVertex = j;
                    }
                }
                book[tempVertex] = 1;
                //更新dis陣列的值
                for (int k = 1; k < v; k++)
                {
                    if( inf > map[tempVertex,k])
                    {
                        if (dis[k] > dis[tempVertex] + map[tempVertex, k])
                            dis[k] = dis[tempVertex] + map[tempVertex, k];
                    }
                }
            }
            /*
             TakeWhile 與 SkipWhile 效果 就如字面上意思 
             TakeWhile只要判斷到 false 就會跳出判斷了
             
            lambda ex:
             dis.SkipWhile( (x,y) => x.ToString()=="0" && y < 2 )
                            ***上面的 y 是 代表陣列的索引值***
             */
            Console.WriteLine("頂點 1 到 各頂點最短路徑長為："+string.Join(" ", dis.SkipWhile(x=>x.ToString()=="0").ToList().ConvertAll(new Converter<int, string>(x=>x.ToString()))));
            Console.Read();
        }
    }
}
