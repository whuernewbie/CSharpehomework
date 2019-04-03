using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using System.Xml

namespace OrderManage
{
    public class OrderService
    {
        public List<Order> orders = new List<Order>();

        public bool OrderAdd(Order order)//通过用户建立订单
        {
            //bool same = true;
           // int r = 0;
            //while(same)//产生随机的和已有订单号不同的订单号
            //{
              //  Random random = new Random();
              //  r = random.Next();
              //  same = false;
              //  foreach (Order order1 in orders)
              ///  {
               //     if(r==order1.Id)
                //    {
               //         same = true;
                //    }
              //  }
          //  }
          //  Order order = new Order(customer,r);
            orders.Add(order);
            return true;
            
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

        public bool ItemAdd(Customer customer,Goods good,uint num,uint q)//客户名，订单号，在订单中添加物品
        {
           // Console.WriteLine("请输入商品名称");
            //name = Console.ReadLine();
            //Console.WriteLine("请输入需要的商品数量");
            //while (!(int.TryParse(Console.ReadLine(), out num)&&num>0))
             //   Console.WriteLine("请输入正确的商品数量");
            foreach(Order order1 in orders)
            {
                if (order1.Customer.Equals(customer))
                {
                    OrderDetails orderDetails = new OrderDetails(num,good,q);
                    order1.orderDetails.Add(orderDetails);
                    break;
                }
                //Console.WriteLine("无此订单号");
                return false;
            }
            return true;

        }

        public bool FixNum(Customer customer,uint id,uint newq)//修改订单某个物品数量
        {
            //bool find = false;
            foreach(Order order in orders)
            {
                if(order.Customer.Equals(customer))
                {
                   // find = true;
                    foreach(OrderDetails orderDetails in order.orderDetails)
                    {
                        if(orderDetails.Num==id)
                        {
                            //int num = 0;
                            //Console.WriteLine("重新输入该物品的数量，输入0删除此物品");
                            // while (!(int.TryParse(Console.ReadLine(), out num) && num >= 0))
                            //  Console.WriteLine("请输入正确的商品数量");
                            //  if(num==0)
                            //  {
                            //      order.orderDetails.Remove(orderDetails);
                            //      break;
                            //  }
                            //  else
                            //  {
                            //     orderDetails.Num = num;
                            //      break;
                            //  }
                            orderDetails.Quantity = newq;
                            return true;
                        }

                    }
                    
                    //Console.WriteLine("您的订单中无此商品！");
                    //break;
                }
                
                //if(!find)
                //{
                //Console.WriteLine("无此订单号！");
                // break;
                //}
            }
            return false;
        }

        /*public void DispOrder(Order order)//显示一个订单的详细信息---------通过重写ToString再
        {
            Console.WriteLine("客户名称："+order.Client);
            Console.WriteLine("订单号："+order.Id);
            foreach(OrderDetails orderDetails in order.orderDetails)
            {
                Console.WriteLine("     "+"商品名称:"+orderDetails.Name +" " + "商品数量:"+orderDetails.Num);

            }
        }
        */
        
        public string FindById(int id)//通过订单号显示订单信息
        {
            /*foreach (Order order in orders)
            {
                if(order.Id==id)
                {
                    return order.ToString();
                }
            }
            */
            var s = orders.Where(os => os.Id == id);
            return s.ToString();
        }

        public string FindByClient(Customer customer)//通过用户名查找用户的订单信息
        {
            /* foreach (Order order in orders)
             {
                 if( string.Equals(order.Customer.Name,client))
                 {
                     return order.ToString();
                 }
             }
             */

           var order= this.orders.Where(os =>os.Customer.Equals(customer));
            return order.ToString();//使用linq查找
        }

        public string FindByName(string name)
        {
            string str=" ";
            /*foreach(Order order in orders)
            {
                foreach(OrderDetails orderDetails in order.orderDetails)
                {
                    if(string.Equals(orderDetails.Goods.Name,name))
                    {
                        s+= order.ToString();
                    }
                }
            }
            */
            var s = from os in orders
                    where os.FindName(name)
                    select os;
            foreach (Order order in s) str += order.ToString();
            return str;
        }


        public void Export()
        {
            string xmlString = string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order));
            /*using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());

            }*/
            using (TextWriter textWriter = new StreamWriter("G:\\xmlTest.xml"))
            {
                foreach(Order obj in orders)
                xmlSerializer.Serialize(textWriter, obj);
            }
            
        }

        public  Order  import(string filepath)
        {
            Order t = default(Order);
            string xmlString = File.ReadAllText(filepath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order));
            using (Stream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(xmlStream))
                {
                    Object obj = xmlSerializer.Deserialize(xmlReader);
                    t = (Order)obj;
                }
            }
            return t;
        }




    }
}
