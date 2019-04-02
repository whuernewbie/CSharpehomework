using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Order:IComparable<Order>
    {
        public int Id { get; set; }
        private Customer Customer { get; set; }
        private  List<OrderDetails> orderDetails = new List<OrderDetails>();

        private  Order(Customer customer,int id)
        {
            Customer = customer;
            this.Id = id;
            //List<OrderDetails> orderDetails = new List<OrderDetails>();
        }

        public override bool Equals(object obj)//重写订单的equals
        {
            var order = obj as Order;
            return order != null && order.Id == Id && order.Customer.Equals(Customer);
        }
        public override int GetHashCode()
        {
            var hashCode = 1522632222;
            hashCode = hashCode * -1521134256 + Customer.GetHashCode();
            hashCode = hashCode * -1521134256 + Id.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            String result = $"orderId:{Id}, customer:({Customer})";
            this.orderDetails.ForEach(detail => result += "\n\t" + detail);
            return result;
        }

        public int CompareTo(Order other)//实现订单按总金额排序
        {
            double a = 0, b = 0;
            if (other == null) throw new ArgumentException("other");
            this.orderDetails.ForEach(
                good => a += good.Goods.Price);
            other.orderDetails.ForEach(good => b += good.Goods.Price);
            if (a > b) return 1;
            else if (a < b) return -1;
            else return 0;
        }
        
    }
    
}
