using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_3重要城市_圖的割點
{
    static class ES
    {
        static public int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
    class Program
    {
        static int root;
        static int[] flag,num,low;
        static int index=0;
        static int[,] e;
        static void Main(string[] args)
        {           
            int side;
            string[] tempStr;
            tempStr = Console.ReadLine().Split(' ');
            e = new int[tempStr[0].ToInt() + 1, tempStr[0].ToInt() + 1];
            flag = new int[e.GetLength(0)];
            num = new int[e.GetLength(0)];
            low = new int[e.GetLength(0)];
            side = tempStr[1].ToInt();           
            for(int i =0; i<side;i++)
            {
                tempStr = Console.ReadLine().Split(' ');
                e[tempStr[0].ToInt(), tempStr[1].ToInt()] = 1;
                e[ tempStr[1].ToInt(), tempStr[0].ToInt()] = 1;
            }
            
            root = 1;
            dfs(1, root);
            for (int i = 1; i < flag.Length; i++)
                if (flag[i] == 1)
                    Console.WriteLine(i);
            Console.Read();

        }
        static void dfs(int cur, int father)
        {
            int child = 0;
            index++;
            num[cur] = index;
            low[cur] = index;
            for(int i = 1; i<num.Length;i++)
            {
                if(e[cur,i]==1)
                {
                    if (num[i] == 0)
                    {
                        child++;
                        dfs(i, cur);//深度優先走訪
                        //更新目前頂點 cur 能否存取到最早頂點的時間戳記
                        low[cur] = Math.Min(low[cur], low[i]);
                        //如果目前頂點不是根節點並且滿足 low[i] >= num[cur]，則目前頂點為割點
                        if (cur != root && low[i] >= num[cur])
                            flag[cur] = 1;
                        //如果目前頂點是根節點，在生成樹中根節點必須要有兩個子節點
                        //那麼這個根節點才是割點
                        if (cur == root && child == 2)
                            flag[cur] = 1;
                    }
                    else if (i != father)
                        //否則如果頂點 i 曾經被存取過，並且這個頂點不是目前頂點 cur 的根節點
                        //則需要更新目前節點 cur 能否存取到最早頂點的節間戳記
                        low[cur] = Math.Min(low[cur], num[i]);
                }
            }

        }
    }
}
