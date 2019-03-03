using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[50];
            int sum=0;
            int max;
            int min;
            double avag;
            Console.WriteLine("输入数字来构建一个数组，输入00结束输入");
            String str = Console.ReadLine();
            int count=0;
            while (str!="00")
            {
                bool b = int.TryParse(str, out int a);
                if(b)
                {
                    num[count] = a;
                    count++;
                    sum += a;
            
                }
                else
                {
                    Console.WriteLine("输入字符错误！");
                }
                str = Console.ReadLine();
            }
            num[count] = '\0';
            // int[] num = new int[count];
            Array.Sort(num);
            Array.Reverse(num);
            max = num[0];
            min = num[count-1];
            avag = (double )sum / count;
            Console.WriteLine("数组元素的和为："+sum+"，最大值为："+max+",最小值为："+min+",平均值为："+avag);
            Console.Read();


        }
    }
}
