using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        static void Main(string[] args)
        {
            int op=0;
            string client;
            bool ok = true;
    
            OrderService orderService = new OrderService();
            Console.WriteLine("输入用户名来创建一个用户：");
            client = Console.ReadLine();
            Console.WriteLine("欢迎来到临时版订单管理系统！"+client);
            Console.WriteLine("输入数字来执行相关操作");
            while(ok)
            {
                Console.WriteLine("1.创建订单  2.查询订单  3. 修改订单 4.删除订单 5.退出系统");
                while(!(int.TryParse(Console.ReadLine(), out op)&&op>=1&&op<=5))
                {
                    Console.WriteLine("操作数无效，重新输入操作数！");
                }
                if(op==1)
                {
                    
                    Console.WriteLine( "您的订单号为："+ orderService.OrderAdd(client));
                }
                else if(op==2)
                {
                    int op2= 0;
                    Console.WriteLine("1.输入id查找  2.输入用户名查找  3.输入物品名查找 4.退出");
                    while (!(int.TryParse(Console.ReadLine(), out op2) && op2 >= 1 && op2 <= 4))
                    {
                        Console.WriteLine("操作数无效，重新输入操作数！");
                    }
                    if(op2==1)
                    {
                        Console.WriteLine("输入您要操作的订单号:");
                        int id = 0;
                        while (!(int.TryParse(Console.ReadLine(), out id)))
                        {
                            Console.WriteLine("订单号无效，重新输入订单号！");
                        }
                        orderService.FindById(id);

                    }
                    else if(op2==2)
                    {
                        Console.WriteLine("输入用户名:");
                        string str = Console.ReadLine();
                        orderService.FindByClient(str);
                    }
                    else if(op2==3)
                    {
                        Console.WriteLine("输入物品名:");
                        string str = Console.ReadLine();
                        orderService.FindByName(str);

                    }
                    else if(op2==4)
                    {
                        break;
                    }


                }
                else if(op==3)
                {
                    Console.WriteLine("输入您要操作的订单号:");
                    int id = 0;
                    while (!(int.TryParse(Console.ReadLine(), out id)))
                    {
                        Console.WriteLine("订单号无效，重新输入订单号！");
                    }
                    bool ok1 = true;
                    int op1= 0;
                    while (ok1)
                    {
                        Console.WriteLine("1.添加物品  2.修改物品数量 3.退出");
                        while (!(int.TryParse(Console.ReadLine(), out op1) && op1 >= 1 && op1 <= 3))
                        {
                            Console.WriteLine("操作数无效，重新输入操作数！");
                        }
                        if (op1==1)
                        {
                            orderService.ItemAdd(id);
                        }
                        else if(op1==2)
                        {
                            Console.WriteLine("输入物品名称:");
                            string str = Console.ReadLine();
                            orderService.FixNum(id, str);
                        }
                        
                        else if(op1==3)
                        {
                            break;
                        }
                    }
                }
                else if(op==4)
                {
                    Console.WriteLine("输入您要操作的订单号:");
                    int id = 0;
                    while (!(int.TryParse(Console.ReadLine(), out id)))
                    {
                        Console.WriteLine("订单号无效，重新输入订单号！");
                    }
                    orderService.OrderDel(id);
                 }

            }


        }
    }
}
