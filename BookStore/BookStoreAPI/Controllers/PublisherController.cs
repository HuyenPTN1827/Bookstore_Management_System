using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ImpRep;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherRepository _repository = new PublisherRepository();

        // GET: api/<PublisherController>
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetPublishers()
        {
            return _repository.GetPublishers();
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            return _repository.FindPublisherById(id);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public IActionResult AddPublisher(Publisher publisher)
        {
            _repository.AddPublisher(publisher);
            return NoContent();
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, Publisher publisher)
        {
            var p = _repository.FindPublisherById(id);
            if (p == null)
            {
                return NotFound();
            }

            p.PublisherName = publisher.PublisherName;
            p.Address = publisher.Address;
            p.Phone = publisher.Phone;

            _repository.UpdatePublisher(p);
            return NoContent();
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var p = _repository.FindPublisherById(id);
            if (p == null)
            {
                return NotFound();
            }
            _repository.DeletePublisher(p);
            return NoContent();
        }
    }
}
