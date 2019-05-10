using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Models;

namespace OrderController.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;

            if (_context.Order.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                List< OrderDetail> orderDetails=new List<OrderDetail>();
                OrderDetail orderDetail=new OrderDetail();
                orderDetail.Id=1;
                orderDetail.Name="Apple";
                orderDetail.Price=6;
                orderDetail.Quantity=10;
                orderDetails.Add(orderDetail);
                Order order = new Order(1, 1, "jiang", orderDetails);
                _context.Order.Add(order);
                OrderDetail orderDetail1 = new OrderDetail();
                orderDetail1.Id = 11;
                orderDetail1.Name = "pen";
                orderDetail1.Price = 16;
                orderDetail1.Quantity = 10;
                orderDetails.Add(orderDetail1);
                Order order1 = new Order(2, 2, "jiang", orderDetails);
                _context.Order.Add(order1);
                _context.SaveChanges();//≥ı ºªØ
            }
        }

        
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/GetById/1
       // [Route("Order/GetById/{OrderId}")]
        [HttpGet("{OrderId}")]
        public async Task<ActionResult<Order>> GetById(long OrderId)
        {
            var Order = await _context.Order.FindAsync(OrderId);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        //GET: api/RemoveById/1
        
        [HttpDelete("{OrderId}")]
        public async Task<ActionResult<IEnumerable<Order>>> RemoveById(long OrderId)
        {
            var Order = await _context.Order.FindAsync(OrderId);
            if(Order==null)
            {
                return NotFound();
            }
            else{
                _context.Order.Remove(Order);
                return await _context.Order.ToListAsync();

            }
        }


        // POST api/values
        [HttpPost]
        public ActionResult<Order> PostNew(long id, Order item)
        {
            if (id != item.OrderId)
            {
                return BadRequest();
            }
            _context.Order.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }

        /*//Get:qpi/AddOrder/json
        [HttpGet("{CUSName}")]
        public async Task<ActionResult<Order>>  GetByName(string CUSName)
        {
            var Order = await _context.Order.FindAsync(CUSName);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        //*/




    }
}