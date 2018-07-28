using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1解密QQ號_佇列
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"解密規則如下:");
            Console.WriteLine($"將第一個數刪除,緊接著將第二個數字放到這串數的末尾");
            Console.WriteLine($"再將第三個數刪除並將第四個數放置這串數的末尾以此類推");
            Console.WriteLine($"直到剩下最後一個數,也將最後個數字刪除");
            Console.WriteLine($"按照刪除順序把這些刪除的數字串再一起就解密出來了");
            Console.WriteLine($"ex: 加密數=631758924");
            Console.WriteLine($"1. 631758924");
            Console.WriteLine($"2. 17589243");
            Console.WriteLine($"3. 5892437");
            Console.WriteLine($"4. 924378");
            Console.WriteLine($"5. 43782");
            Console.WriteLine($"6. 7823");
            Console.WriteLine($"7. 238");
            Console.WriteLine($"8. 83");
            Console.WriteLine($"9. 3");
            Console.WriteLine($"Ans. 615947283");
            Console.WriteLine("-----------------------------------------------------");  
            Console.WriteLine("請輸入欲解密數字");
            string s = Console.ReadLine();
            Queue<string> encode = new Queue<string>();
            for(int i = 0; i <s.Length;i++)
            {
                encode.Enqueue(s.Substring(i, 1));
            }
            Queue<string> ans = new Queue<string>();
            decodeQQ(encode, ans);
            Console.Write("ANS ： ");
            int ans_Count = ans.Count;
            for (int i = 0; i < ans_Count; i++)
                Console.Write(ans.Dequeue());
            Console.Read();
        }
        static void decodeQQ(Queue<string> encode,Queue<string> ans)
        {
            ans.Enqueue(encode.Dequeue());
            if (encode.Count > 0)
                encode.Enqueue(encode.Dequeue());
            else
                return;
            decodeQQ(encode, ans);
        }
    }
}
