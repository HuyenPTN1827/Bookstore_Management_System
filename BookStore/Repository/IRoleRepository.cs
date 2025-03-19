using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role FindRoleById(int id);
        void AddRole(Role r);
        void UpdateRole(Role r);
        void DeleteRole(Role r);
    }
}
