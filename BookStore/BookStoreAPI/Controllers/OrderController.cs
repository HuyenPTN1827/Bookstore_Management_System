using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ImpRep;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return repository.GetOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var o = repository.GetOrderById(id);
            if (o == null)
            {
                return NotFound();
            }
            return o;
        }

        [HttpGet("account/{accountId}")]
        public ActionResult<IEnumerable<Order>> GetOrdersByMemberId(int accountId)
        {
            var o = repository.GetOrdersByAccountId(accountId);
            if (o == null)
            {
                return NotFound();
            }
            return o;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                var o = new Order
                {
                    OrderDate = DateTime.Now,
                    DeliveryDate = null,
                    AccountId = order.AccountId,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status
                };

                return repository.AddOrder(o);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new order record");
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            var o = repository.GetOrderById(id);
            if (o == null)
            {
                return NotFound();
            }

            o.DeliveryDate = order.DeliveryDate;
            o.AccountId = order.AccountId;
            o.TotalAmount = order.TotalAmount;
            o.Status = order.Status;

            repository.UpdateOrder(o);
            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var o = repository.GetOrderById(id);
            if (o == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(o);
            return NoContent();
        }
    }
}
