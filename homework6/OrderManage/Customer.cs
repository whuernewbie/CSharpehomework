using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    public class Customer
    {
        public uint Id { get; set; }
        public string Name { get; set;}

        public Customer(uint Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"customerId:{Id},customerName:{Name}";
        }
    }
}
