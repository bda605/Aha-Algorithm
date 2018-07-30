using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2炸彈人
{
    class rank
    {
        public int kill;
        public int locationX;
        public int locationY;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("你現在有一個炸彈，可以放在如下的地圖");
            Console.WriteLine("試問如何才能炸死最多敵人");
            Console.WriteLine("註: # 為牆壁  E 為敵人  . 為 空地");
            string[,] map = new string[,]
            {
                { "#","#","#","#","#","#","#","#","#","#","#","#","#"},
                { "#","E","E",".","E","E","E","#","E","E","E",".","#"},
                { "#","#","#",".","#","E","#","E","#","E","#","E","#"},
                { "#",".",".",".",".",".",".",".","#",".",".","E","#"},
                { "#","E","#",".","#","#","#",".","#","E","#","E","#"},
                { "#","E","E",".","E","E","E",".","#",".","E","E","#"},
                { "#","E","#",".","#","E","#",".","#",".","#","#","#"},
                { "#","#","E",".",".",".","E",".",".",".",".",".","#"},
                { "#","E","#",".","#","E","#","#","#",".","#","E","#"},
                { "#",".",".",".","E","#","E","E","E",".","E","E","#"},
                { "#","E","#",".","#","E","#","E","#",".","#","E","#"},
                { "#","E","E",".","E","E","E","#","E",".","E","E","#"},
                { "#","#","#","#","#","#","#","#","#","#","#","#","#"}
            };
            for (int i = 0; i <= map.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= map.GetUpperBound(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }        
            int kill,x,y = 0;
            rank rk = new rank();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i,j] == ".")
                    {
                        kill = 0;
                        x = i;y = j;
                        //向下統計
                        while(map[x,y] !="#")
                        {
                            
                            if (map[x, y] == "E")
                                kill++;
                            x++;                       
                        }
                        x = i; y = j;
                        //向上統計
                        while (map[x, y] != "#")
                        {

                            if (map[x, y] == "E")
                                kill++;
                            x--;
                        }
                        //向右統計
                        x = i; y = j;
                        while (map[x, y] != "#")
                        {

                            if (map[x, y] == "E")
                                kill++;
                            y++;
                        }
                        //向左統計
                        x = i; y = j;
                        while (map[x, y] != "#")
                        {

                            if (map[x, y] == "E")
                                kill++;
                            y--;
                        }
                        if(kill > rk.kill)
                        {
                            rk.kill = kill;
                            rk.locationX = i;
                            rk.locationY = j;
                        }
                    }
                }
            }
            Console.WriteLine($"將炸彈放置在 {rk.locationX} , {rk.locationY} 處  , 最多可以消滅 {rk.kill} 個 敵人");
            Console.Read();
        }
    }
}
