using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace OrderAPI.Models
{
   public class Order :IComparable<Order>{

    public Order() {
            Details = new List<OrderDetail>();
    }

  public Order(int orderId, int CustomerId, string CUSName,List<OrderDetail> details) {
             OrderId = orderId;
            this.CUSName = CUSName;
            this.CustomerId = CustomerId;
            this.Details = details;
    }

    [Key]
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string CUSName { get; set; }
    public List<OrderDetail> Details { get; set; }
        

    public int CompareTo(Order other) {
     if(other==null) return 1;
     return OrderId - other.OrderId;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             OrderId == order.OrderId;
    }

    public override int GetHashCode() {
      return 2108858624 + OrderId.GetHashCode();
    }





    /// <summary>
    /// remove orderDetail by index num
    /// </summary>
    /// <param name="num">number of the orderDetail to be removed</param>
    public void RemoveDetails(int num) {
      Details.RemoveAt(num);
    }

    public override string ToString() {
      String result = $"orderId:{OrderId}, customerName:({CUSName}),customerID:({CustomerId})";
      Details.ForEach(detail => result += "\n\t" + detail);
      return result;
    }


  }
}