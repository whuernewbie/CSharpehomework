using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Goods
    {
        private double price;
        public uint Id { get; set; }
        public string Name { get; set;}

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        public Goods(uint id, string name,double value)
        {
            Id = id;
            Name = name;
            Price = value;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }

    }
}
