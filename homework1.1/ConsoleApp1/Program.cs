using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string  s = "";
            string a = "";
            Console.WriteLine("请输入乘数：");
            s = Console.ReadLine();
            Console.WriteLine("请输入被乘数：");
            a = Console.ReadLine();
            Console.WriteLine("他们的乘积为：");
            double b = double.Parse(s) * double.Parse(a);
            Console.WriteLine(b);
            Console.Read();


        }
    }
}
