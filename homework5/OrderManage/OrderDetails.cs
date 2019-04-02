using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderDetails
    {
        public uint Num { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }

        public OrderDetails(uint id, Goods goods, uint quantity)
        {
            this.Num = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Num}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetails;
            return detail != null &&
                Goods.Id == detail.Goods.Id &&
                Quantity == detail.Quantity;
        }
        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
