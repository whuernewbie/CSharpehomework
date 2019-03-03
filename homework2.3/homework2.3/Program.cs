using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] num = new int[101];//建立一个全部都是0的，一共有101个元素的数组，如果将对应下标的值由0变为1，则表示去掉该下标数字
            for(int i=2;i<=100;i++)
            {
                while(i<101&& num[i] == 1 )
                {
                    i++;
                }//找到数组中下一个没有被删除的数字
                int a = i;//防止删除这个数字
                while ((a += i) <= 100)
                {
                    num[a] = 1;//删除该数字的100以内的所有倍数（不包括本身
                }
            }
            for(int i=2;i<=100;i++)
            {
                if(num[i]==0)
                {
                    Console.WriteLine(i+" ");//输出2~100所有没有被删除的数字
                }
            }
            Console.Read();

        }
    }
}
