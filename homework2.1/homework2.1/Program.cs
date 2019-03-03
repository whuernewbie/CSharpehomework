using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个正整数");
            String b;
            b=Console.ReadLine();
            bool test = int.TryParse(b, result: out int a);
            int [] num=new int[50];
            int count = 0;
            if(test)
            {
                for (int i = 2; i <= a; i++)
                {
                    if(a%i==0)
                    {
                        num[count] = i;
                        count++;
                        a = a / i;
                        i--;
                    }
                }
                if (count == 1)
                {
                    Console.WriteLine("这是一个素数");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write(" " + num[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("输入字符无效");
            }
            Console.Read();
        }
    }
}
