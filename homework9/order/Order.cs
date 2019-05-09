using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

  /// <summary>
  /// Order class
  /// </summary>
  [Serializable]
  public class Order :IComparable<Order>{

    

    /// <summary>
    ///  default constructor
    /// </summary>
    public Order() {
            Details = new List<OrderDetail>();
    }

  public Order(int orderId, uint CustomerId, string CUSName,List<OrderDetail> details) {
      Id = orderId;
            this.CUSName = CUSName;
            this.CustomerId = CustomerId;
            this.Details = details;

    }

    /// <summary>
    /// order's id
    /// </summary>
    [Key]
    public int Id { get; set; }
    public uint CustomerId { get; set; }
    public string CUSName { get; set; }
    public List<OrderDetail> Details { get; set; }
        
        /* public float TotalAmount {
           get => details.Sum(d => d.Amount);
         }
         */



        /// <summary>
        /// add new orderDetail into the order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
      /*  public void AddDetails(OrderDetail orderDetail) {
      if (this.Details.Contains(orderDetail)) {
        throw new Exception($"orderDetail of the goods ({orderDetail.Name}) exists in order {Id}");
      }
      details.Add(orderDetail);
    }
    */

    public int CompareTo(Order other) {
     if(other==null) return 1;
     return Id - other.Id;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             Id == order.Id;
    }

    public override int GetHashCode() {
      return 2108858624 + Id.GetHashCode();
    }





    /// <summary>
    /// remove orderDetail by index num
    /// </summary>
    /// <param name="num">number of the orderDetail to be removed</param>
    public void RemoveDetails(int num) {
      Details.RemoveAt(num);
    }

    public override string ToString() {
      String result = $"orderId:{Id}, customerName:({CUSName}),customerID:({CustomerId})";
      Details.ForEach(detail => result += "\n\t" + detail);
      return result;
    }


  }
}
