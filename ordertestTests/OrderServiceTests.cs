using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
       // [TestMethod()]
        //public void OrderServiceTest()
        //{
         //   Assert.Fail();
        //}

        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1,customer);

            orderService.AddOrder(order);
            Assert.AreEqual(order, orderService.GetById(1));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            Customer customer2 = new Customer(1, "wang");
            Order order2 = new Order(1, customer2);

            orderService.Update(order2);

            Assert.AreEqual(order2, orderService.GetById(1));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            Assert.AreEqual(order, orderService.GetById(1));
           
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            orderService.RemoveOrder(1);

            Assert.IsNull(orderService.GetById(1));
        }

        [TestMethod()]
        public void QueryAllTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            List<Order> orders=new List<Order>();
            orders.Add(order);


            Assert.IsTrue(orders.Count == orderService.QueryAll().Count && orders.Count(o => !orderService.QueryAll().Contains(o))==0);
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            List<Order> orders = new List<Order>();
            orders.Add(order);

            Assert.IsTrue(orders.Count == orderService.QueryByCustomerName("long").Count && orders.Count(o => !orderService.QueryByCustomerName("long").Contains(o)) == 0);

        }

        [TestMethod()]
        public void QueryByTotalAmountTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            Goods goods = new Goods(2, "Apple", 5);
            OrderDetail orderDetail = new OrderDetail(goods, 3);
            order.AddDetails(orderDetail);
            orderService.AddOrder(order);

            List<Order> orders = new List<Order>();
            orders.Add(order);

            Assert.IsTrue(orders.Count == orderService.QueryByTotalAmount(15).Count && orders.Count(o => !orderService.QueryByTotalAmount(15).Contains(o)) == 0);



        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            Goods goods = new Goods(2, "Apple", 5);
            OrderDetail orderDetail = new OrderDetail(goods, 3);
            List<Order> orders =new List<Order>();
            
            order.AddDetails(orderDetail);
            orderService.AddOrder(order);
            orders.Add(order);

            Assert.IsTrue(orders.Count == orderService.QueryByGoodsName("Apple").Count && orders.Count(o => !orderService.QueryByGoodsName("Apple").Contains(o)) == 0);
        }

        [TestMethod()]
        public void SortTest()
        {
            OrderService orderService = new OrderService();

            Customer customer = new Customer(1, "long");
            Order order = new Order(1, customer);
            orderService.AddOrder(order);

            Customer customer2 = new Customer(6, "zhang");
            Order order2 = new Order(6, customer);
            orderService.AddOrder(order2);


            Customer customer3 = new Customer(3, "li");
            Order order3 = new Order(3, customer);
            orderService.AddOrder(order3);

            List<Order> orders = new List<Order>();
            orders.Add(order);
            orders.Add(order3);
            orders.Add(order2);


            orderService.Sort((o1, o2) => o2.CompareTo(o1));
            Assert.IsTrue(orders.Count == orderService.QueryAll().Count && orders.Count(o => !orderService.QueryAll().Contains(o)) == 0);


        }

       /* [TestMethod()]
        public void ExportTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
        */
    }
}