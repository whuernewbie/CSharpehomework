using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

  /// <summary>
  /// OrderDetail class : a entry of an order object
  /// to record the goods and its quantity
  /// </summary>
 public class OrderDetail {
   
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public float Price { get; set; }

        public OrderDetail() { }

        public override bool Equals(object obj) {
            var detail = obj as OrderDetail;
            return detail != null && Id == detail.Id;
         
 }

 public override int GetHashCode() {
      return 785010553 + EqualityComparer<OrderDetail>.Default.GetHashCode();
    }





    /// <summary>
    /// override ToString
    /// </summary>
    /// <returns>string:message of the OrderDetail object</returns>
    //public override string ToString() {
    //  return $"orderDetail:{Goods},{Quantity}";
    //}


  }
}
