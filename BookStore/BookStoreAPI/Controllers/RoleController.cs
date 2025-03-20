using Microsoft.AspNetCore.Mvc;
using Repository.ImpRep;
using Repository;
using BusinessObject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepository _repository = new RoleRepository();

        // GET: api/<RoleController>
        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            return _repository.GetRoles();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleById(int id) 
        {
            return _repository.FindRoleById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult AddRoke(Role role)
        {
            _repository.AddRole(role);
            return NoContent();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, Role role)
        {
            var r = _repository.FindRoleById(id);
            if (r == null)
            {
                return NotFound();
            }

            r.RoleName = role.RoleName;

            _repository.UpdateRole(role);
            return NoContent();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var r = _repository.FindRoleById(id);
            if (r == null)
            {
                return NotFound();
            }
            _repository.DeleteRole(r);
            return NoContent();
        }
    }
}
