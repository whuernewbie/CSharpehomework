using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.Entity;
using order;

namespace ordertest {
  /// <summary>
  /// OrderService
  /// </summary>
  public class OrderService {

    //private List<Order> orderList;
    /// <summary>
    /// constructor
    /// </summary>
 
    /// <summary>
    /// add new order
    /// </summary>
    /// <param name="order">the order to be added</param>
    public void AddOrder(Order order) {
            using (var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
    }

    /// <summary>
    /// update the order
    /// </summary>
    /// <param name="order">the order to be updated</param>
    public void Update(Order order) {
      RemoveOrder(order.Id);
           using(var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Added;
                db.SaveChanges();
            }
        }///更新订单

    /// <summary>
    /// query by orderId
    /// </summary>
    /// <param name="orderId">id of the order to find</param>
    /// <returns>List<Order></returns> 
    public Order GetById(int orderId) {
            using(var db = new OrderDB())
            {
                return db.Order.Include("Details").SingleOrDefault(o => o.Id == orderId);//找到order
            }
        }

    /// <summary>
    /// remove order
    /// </summary>
    /// <param name="orderId">id of the order which will be removed</param> 
    public void RemoveOrder(int orderId) {
            Order order = GetById(orderId);
            using(var db = new OrderDB())
            {
                db.Entry(order).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }//数据库删除订单

        public void RemoveGoods(int orderId,int GoodsId)
        {
            
            Order order = GetById(orderId);
            RemoveOrder(orderId);
            order.Details.RemoveAll(o => o.Id == GoodsId);
            Update(order);
        }//删除货物

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAll() {
            using(var db = new OrderDB())
            {
                return db.Order.Include("Details").ToList<Order>();
            }
        }


    /// <summary>
    /// query by goodsName
    /// </summary>
    /// <param name="goodsName">the name of goods in order's orderDetail</param>
    /// <returns></returns> 
   /* public List<Order> QueryByGoodsName(string goodsName) {
            using (var db = new OrderDB())
            {
                return db.OrderDetail
                  .Where(o => o.Name.Equals(goodsName)).ToList<Order>();
            }
        }
        */


    /// <summary>
    /// query by customerName
    /// </summary>
    /// <param name="customerName">customer name</param>
    /// <returns></returns> 
    public List<Order> QueryByCustomerName(string customerName) {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Details")
                  .Where(o => o.CUSName.Equals(customerName)).ToList<Order>();
            }
        }

   /* public void Sort(Comparison<Order> comparison) {
      orderList.Sort(comparison);
    }

    /// <summary>
    /// Exprot the orders to an xml file.
    /// </summary>
    public void Export(String fileName) {
      if (Path.GetExtension(fileName) != ".xml")
        throw new ArgumentException("the exported file must be a xml file!");
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
        xs.Serialize(fs, this.orderList);
      }
    }

    /// <summary>
    /// import from an xml file
    /// </summary>
    public List<Order> Import(string path) {
      if (Path.GetExtension(path) != ".xml")
        throw new ArgumentException($"{path} isn't a xml file!");
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      List<Order> result = new List<Order>();
      try {
        using (FileStream fs = new FileStream(path, FileMode.Open)) {
          return (List<Order>)xs.Deserialize(fs);
        }
      }catch(Exception e) {
        throw new ApplicationException("import error:" + e.Message);
      }
     
    }
    */

  }
}
