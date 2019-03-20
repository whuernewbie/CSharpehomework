using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{

    class Order
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public  List<OrderDetails> orderDetails = new List<OrderDetails>();

        public  Order(int id, string client)
        {
            this.Client = client;
            this.Id = id;
            //List<OrderDetails> orderDetails = new List<OrderDetails>();
        }


        
    }
    
}
