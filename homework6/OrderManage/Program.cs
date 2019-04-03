using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);

                OrderDetails orderDetails1 = new OrderDetails(1, apple, 8);
                OrderDetails orderDetails2 = new OrderDetails(2, eggs, 2);
                OrderDetails orderDetails3 = new OrderDetails(3, milk, 1);

                Order order1 = new Order(customer1, 1);
                Order order2 = new Order(customer2, 2);
                Order order3 = new Order(customer2, 3);
                order1.orderDetails.Add(orderDetails1);
                order1.orderDetails.Add(orderDetails2);
                order1.orderDetails.Add(orderDetails3);
                //order1.AddOrderDetails(orderDetails3);
                order2.orderDetails.Add(orderDetails2);
                order2.orderDetails.Add(orderDetails3);
                order3.orderDetails.Add(orderDetails3);

                OrderService os = new OrderService();
                os.OrderAdd(order1);
                os.OrderAdd(order2);
                os.OrderAdd(order3);
                os.Export();

                Console.WriteLine("GetAllOrders");
                //List<Order> orders = os.QueryAllOrders();

                foreach (Order order in os.orders)
                    Console.WriteLine(order.ToString());

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                //orders = os.QueryByCustomerName("Customer2");
                //foreach (Order order in os.orders)
                // Console.WriteLine(order.ToString());
                Console.WriteLine(os.FindByClient(customer2));

                //Console.WriteLine("GetOrdersByGoodsName:'apple'");
                //orders = os.QueryByGoodsName("apple");
                //foreach (Order order in orders)
                Console.WriteLine(os.FindByName("apple"));

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.orders.Remove(order2);
                os.orders.ForEach(
                    od => Console.WriteLine(od));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
