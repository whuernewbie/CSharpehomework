using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderService
    {
        private List<Order> orders = new List<Order>();

        public int OrderAdd(string client)//通过用户名建立订单
        {
            bool same = true;
            int r = 0;
            while(same)//产生随机的和已有订单号不同的订单号
            {
                Random random = new Random();
                r = random.Next();
                same = false;
                foreach (Order order1 in orders)
                {
                    if(r==order1.Id)
                    {
                        same = true;
                    }
                }
            }
            Order order = new Order(r, client);
            orders.Add(order);
            return order.Id;
            
        }

        public void OrderDel(int id)//删除订单
        {
            foreach(Order order in orders)
            {
                if(order.Id==id)
                {
                    orders.Remove(order);//通过订单号删除订单
                }
            }
        }

        public void ItemAdd(int id)//客户名，订单号，在订单中添加物品
        {
            int num;
            string name;
            Console.WriteLine("请输入商品名称");
            name = Console.ReadLine();
            Console.WriteLine("请输入需要的商品数量");
            while (!(int.TryParse(Console.ReadLine(), out num)&&num>0))
                Console.WriteLine("请输入正确的商品数量");
            foreach(Order order1 in orders)
            {
                if (order1.Id == id)
                {
                    OrderDetails orderDetails = new OrderDetails(name,num);
                    order1.orderDetails.Add(orderDetails);
                    break;
                }
                Console.WriteLine("无此订单号");
            }

        }

        public void FixNum(int id,string name)//修改订单某个物品数量
        {
            bool find = false;
            foreach(Order order in orders)
            {
                if(order.Id==id)
                {
                    find = true;
                    foreach(OrderDetails orderDetails in order.orderDetails)
                    {
                        if(string.Equals(orderDetails.Name,name))
                        {
                            int num = 0;
                            Console.WriteLine("重新输入该物品的数量，输入0删除此物品");
                            while (!(int.TryParse(Console.ReadLine(), out num) && num >= 0))
                                Console.WriteLine("请输入正确的商品数量");
                            if(num==0)
                            {
                                order.orderDetails.Remove(orderDetails);
                                break;
                            }
                            else
                            {
                                orderDetails.Num = num;
                                break;
                            }
                        }

                    }
                    Console.WriteLine("您的订单中无此商品！");
                    break;
                }
                if(!find)
                {
                    Console.WriteLine("无此订单号！");
                    break;
                }
            }
        }

        public void DispOrder(Order order)//显示一个订单的详细信息
        {
            Console.WriteLine("客户名称："+order.Client);
            Console.WriteLine("订单号："+order.Id);
            foreach(OrderDetails orderDetails in order.orderDetails)
            {
                Console.WriteLine("     "+"商品名称:"+orderDetails.Name +" " + "商品数量:"+orderDetails.Num);

            }
            

        }

        public void FindById(int id)//通过订单号显示订单信息
        {
            foreach (Order order in orders)
            {
                if(order.Id==id)
                {
                    DispOrder(order);
                }
            }
        }

        public void FindByClient(string client)//通过用户名查找用户的订单信息
        {
            foreach (Order order in orders)
            {
                if( string.Equals(order.Client,client))
                {
                    DispOrder(order);
                }
            }
        }

        public void FindByName(string name)
        {
            foreach(Order order in orders)
            {
                foreach(OrderDetails orderDetails in order.orderDetails)
                {
                    if(orderDetails.Name==name)
                    {
                        DispOrder(order);
                    }
                }
            }
        }


    }
}
