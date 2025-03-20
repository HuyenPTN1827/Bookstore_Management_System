using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ImpRep;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountRepository _repository = new AccountRepository();

        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        [HttpGet("Search/{keyword}")]
        public ActionResult<IEnumerable<Account>> SearchAccount(string keyword)
        {
            return _repository.SearchAccount(keyword);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
            return _repository.FindAccountById(id);
        }

        [HttpGet("Email/{email}")]
        public ActionResult<Account> GetAccountByEmail(string email)
        {
            return _repository.FindAccountByEmail(email);
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult AddAccount(AccountRequest account)
        {
            var acc = new Account
            {
                Username = account.Username,
                Password = account.Password,
                Fullname = account.Fullname,
                Email = account.Email,
                Address = account.Address,
                Phone = account.Phone,
                Gender = account.Gender,
                DoB = account.DoB,
                RoleId = account.RoleId
            };
            _repository.AddAccount(acc);
            return NoContent();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, AccountRequest account)
        {
            var acc = _repository.FindAccountById(id);
            if (acc == null)
            {
                return NotFound();
            }

            acc.Username = account.Username;
            acc.Password = account.Password;
            acc.Fullname = account.Fullname;
            acc.Email = account.Email;
            acc.Address = account.Address;
            acc.Phone = account.Phone;
            acc.Gender = account.Gender;
            acc.DoB = account.DoB;
            acc.RoleId = account.RoleId;

            _repository.UpdateAccount(acc);
            return NoContent();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var acc = _repository.FindAccountById(id);
            if (acc == null)
            {
                return NotFound();
            }
            _repository.DeleteAccount(acc);
            return NoContent();
        }
    }
}
