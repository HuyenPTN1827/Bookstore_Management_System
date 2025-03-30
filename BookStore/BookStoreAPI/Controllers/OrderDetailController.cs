using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.ImpRep;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        private IBookRepository bookRepository = new BookRepository();
        private IEventRepository eventRepository = new EventRepository();

        // GET: api/<OrderDetailController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return orderDetailRepository.GetOrderDetails();
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("order/{id}")]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int id)
        {
            return orderDetailRepository.GetOrderDetailByOrderId(id);
        }

        [HttpGet("{orderId}/{bookId}")]
        public ActionResult<OrderDetail> GetOrderDetailByOrderIdAndBookId(int orderId, int bookId)
        {
            return orderDetailRepository.GetOrderDetailByOrderIdAndBookId(orderId, bookId);
        }

        // POST api/<OrderDetailController>
        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var book = bookRepository.GetBookById(orderDetail.BookId);
                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                var activeEvents = eventRepository.GetActiveEventIds();

                var discountedPrice = book.BookDiscounts
                    .Where(d => activeEvents.Contains(d.EventId))
                    .Select(d => book.Price * (1 - d.DiscountPercent / 100))
                    .FirstOrDefault();

                var finalPrice = discountedPrice > 0 ? discountedPrice : book.Price;

                var od = new OrderDetail
                {
                    OrderId = orderDetail.OrderId,
                    BookId = orderDetail.BookId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = finalPrice
                };

                orderDetailRepository.AddOrderDetail(od);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new order detail record");
            }
        }

        // PUT api/<OrderDetailController>/5 
        [HttpPut("{orderId}/{bookId}")]
        public IActionResult PutOrderDetailByOrderIdAndBookId(int orderId, int bookId, OrderDetail orderDetail)
        {
            var od = orderDetailRepository.GetOrderDetailByOrderIdAndBookId(orderId, bookId);
            if (od == null)
            {
                return NotFound();
            }

            var book = bookRepository.GetBookById(orderDetail.BookId);

            var activeEvents = eventRepository.GetActiveEventIds();

            var discountedPrice = book.BookDiscounts
                .Where(d => activeEvents.Contains(d.EventId))
                .Select(d => book.Price * (1 - d.DiscountPercent / 100))
                .FirstOrDefault();

            var finalPrice = discountedPrice > 0 ? discountedPrice : book.Price;

            od.OrderId = orderId;
            od.BookId = bookId;
            od.Quantity = orderDetail.Quantity;
            od.UnitPrice = finalPrice;

            orderDetailRepository.UpdateOrderDetail(od);
            return NoContent();
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{orderId}/{bookId}")]
        public IActionResult DeleteOrderDetailByOrderIdAndProductId(int orderId, int bookId)
        {
            var od = orderDetailRepository.GetOrderDetailByOrderIdAndBookId(orderId, bookId);
            if (od == null)
            {
                return NotFound();
            }
            orderDetailRepository.DeleteOrderDetail(od);
            return NoContent();
        }
    }
}
