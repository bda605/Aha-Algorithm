using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3紙牌遊戲_小貓釣魚
{
    class Program
    {

        static void test2()
        {

            /*
        * 小猫钓鱼游戏
        * 输入： 数组A 2,4,1,2,5,6
        *       数组B 3,1,3,5,6,4 
        * 输出：A或者B
        * */

            int[] A = new int[] { 2, 4, 1, 2, 5, 6, 0, 0, 0, 0, 0, 0, 0 };
            int[] B = new int[] { 3, 1, 3, 5, 6, 4, 0, 0, 0, 0, 0, 0, 0 };
            int aHead = 0, aTail = 6;
            int bHead = 0, bTail = 6;
            int[] Stack = new int[A.Length * 2];
            int sTop = 0;
            while (aHead != aTail && bHead != bTail) //如果小A和小B手里都有牌
            {
                //A
                Stack[sTop++] = A[aHead]; //小A出牌
                A[aHead] = 0; //将小A出掉的牌置零，用于调试可不加
                aHead++;
                if (aHead == A.Length)
                {
                    aHead = 0;
                }
                for (int i = 0; i < sTop - 1; i++) //检查桌面上面有没有和小A出的牌面相同
                {
                    if (Stack[i] == Stack[sTop - 1])
                    {
                        for (int j = sTop - 1; j >= i; j--) //如果有，依次取牌插回小A手里
                        {
                            A[aTail] = Stack[j];
                            Stack[j] = 0;
                            sTop--;
                            aTail++;
                            if (aTail == A.Length)
                            {
                                aTail = 0;
                            }
                        }
                    }
                }
                //B
                Stack[sTop++] = B[bHead];
                B[bHead] = 0;
                bHead++;
                if (bHead == B.Length)
                {
                    bHead = 0;
                }
                for (int i = 0; i < sTop - 1; i++)
                {
                    if (Stack[i] == Stack[sTop - 1])
                    {
                        for (int j = sTop - 1; j >= i; j--)
                        {
                            B[bTail] = Stack[j];
                            Stack[j] = 0;
                            sTop--;
                            bTail++;
                            if (bTail == B.Length)
                            {
                                bTail = 0;
                            }
                        }
                    }
                }
            }
            if (aHead == aTail)
            {
                Console.WriteLine("B win!");
            }
            else
            {
                Console.WriteLine("A win!");
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            /*
    規則如下：
    1.兩人交替打出手上的牌
    2.如果打出的牌與桌面上的任一張相同 , 則將桌面上的牌全部取走
    3.以此類推 先將手牌出完的獲勝
    */
            Console.WriteLine("玩家 A 手牌(請以空格分隔)：");
            Queue<int> playerA = new Queue<int>();
            string[] temp = Console.ReadLine().Split(' ');
            foreach (string s in temp)
            {
                playerA.Enqueue(int.Parse(s));
            }
            Console.WriteLine("玩家 B 手牌(請以空格分隔)：");
            Queue<int> playerB = new Queue<int>();
            temp = Console.ReadLine().Split(' ');
            foreach (string s in temp)
            {
                playerB.Enqueue(int.Parse(s));
            }
            int bookCount, playerCount;

            Stack<int> book = new Stack<int>();
            while (playerA.Count != 0 && playerB.Count != 0)
            {

                if (book.Contains(playerA.Peek()))
                {
                    int repeat = playerA.Peek();
                    playerA.Enqueue(playerA.Dequeue());
                    bookCount = book.Count;
                    for (int i = 0; i < bookCount; i++)
                    {
                        if (book.Peek() == repeat)
                            i = bookCount - 1;
                        playerA.Enqueue(book.Pop());
                    }
                }
                else
                    book.Push(playerA.Dequeue());

                if (book.Contains(playerB.Peek()))
                {
                    int repeat = playerB.Peek();
                    playerB.Enqueue(playerB.Dequeue());
                    bookCount = book.Count;
                    for (int i = 0; i < bookCount; i++)
                    {
                        if (book.Peek() == repeat)
                            i = bookCount - 1;
                        playerB.Enqueue(book.Pop());
                    }
                }
                else
                    book.Push(playerB.Dequeue());



                /*    Console.Write("\n玩家 A 的手牌為");
                    playerCount = playerA.Count;
                    for (int i = 0; i < playerCount; i++)
                    {
                        Console.Write(" " + playerA.Peek());
                        playerA.Enqueue(playerA.Dequeue());
                    }
                    Console.Write("\n玩家 B 的手牌為");
                    playerCount = playerB.Count;
                    for (int i = 0; i < playerCount; i++)
                    {
                        Console.Write(" " + playerB.Peek());
                        playerB.Enqueue(playerB.Dequeue());
                    }
                    bookCount = book.Count;
                    Stack<int> tempStack = new Stack<int>();
                    Console.Write("\n桌上的牌為");
                    for (int i = 0; i < bookCount; i++)
                    {
                        Console.Write(" " + book.Peek());
                        tempStack.Push(book.Pop());
                    }
                    for(int i = 0;i<bookCount;i++)
                    {
                        book.Push(tempStack.Pop());
                    }*/


            }

            if (playerA.Count == 0)
            {
                Console.WriteLine("\n玩家 B 獲勝");
                Console.Write("玩家 B 的手牌為");
                playerCount = playerB.Count;
                for (int i = 0; i < playerCount; i++)
                    Console.Write(" " + playerB.Dequeue());
            }
            else
            {
                Console.WriteLine("\n玩家 A 獲勝");
                Console.Write("玩家 A 的手牌為");
                playerCount = playerA.Count;
                for (int i = 0; i < playerCount; i++)
                    Console.Write(" " + playerA.Dequeue());
            }
            bookCount = book.Count;
            Console.Write("\n桌上的牌為");
            for (int i = 0; i < bookCount; i++)
                Console.Write(" " + book.Pop());
            Console.Read();
        }
    }
}
