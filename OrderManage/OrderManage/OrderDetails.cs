using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class OrderDetails
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public OrderDetails(string name,int num)
        {
            this.Name = name;
            this.Num = num;
        }

    }
}
