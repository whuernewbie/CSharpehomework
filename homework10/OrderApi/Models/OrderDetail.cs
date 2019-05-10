using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Models {

  /// <summary>
  /// OrderDetail class : a entry of an order object
  /// to record the goods and its quantity
  /// </summary>
 public class OrderDetail {
   
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public OrderDetail() { }

        public override bool Equals(object obj) {
            var detail = obj as OrderDetail;
            return detail != null && Id == detail.Id;
         
 }

 public override int GetHashCode() {
      return 785010553 + EqualityComparer<OrderDetail>.Default.GetHashCode();
    }
  }
}