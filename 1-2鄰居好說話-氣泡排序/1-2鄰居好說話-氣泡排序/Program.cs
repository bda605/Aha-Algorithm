using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2鄰居好說話_氣泡排序
{
    class student
    {
        public string Name;
        public int Grade;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] readTemp = null;
            Console.WriteLine("請輸入有幾位同學：");
            student[] stu = new student[int.Parse(Console.ReadLine())];
            Console.WriteLine("請輸入姓名及成績(以空格分隔)");
            for(int i = 0; i<stu.Length;i++)                                //讀入 姓名及成績
            {
                readTemp = Console.ReadLine().Split(' ');
                stu[i] = new student();
                stu[i].Name = readTemp[0];
                stu[i].Grade = int.Parse(readTemp[1]);
            }
            student temp = new student();
            for(int i = 0; i < stu.Length-1;i++)                            //進行氣泡排序 陣列兩兩進行比較
            {
                for(int j=i+1;j<stu.Length;j++)
                {
                    if(stu[i].Grade > stu[j].Grade)                         // IF內 運算子 如果是 大於 則 由小排到大 反之
                    {
                        temp = stu[i];                                      //交換
                        stu[i] = stu[j];
                        stu[j] = temp;
                    }
                }
            }
            Console.WriteLine("排序結果(由小到大)");
            for(int i = 0; i<stu.Length;i++)                                //印出結果
            {
                Console.Write(stu[i].Name+" ");
                Console.WriteLine(stu[i].Grade);
            }
            Console.Read();
        }
    }
}
