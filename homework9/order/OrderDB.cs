using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ordertest;

namespace order
{ 
    public class OrderDB:DbContext
    {
        public OrderDB():base("OrderDataBase")
        {

        }
        public  DbSet<Order> Order { get; set; }

        public DbSet <OrderDetail> OrderDetail { get; set; }

    }
}
