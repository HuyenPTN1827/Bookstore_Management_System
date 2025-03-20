using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class RoleRepository : IRoleRepository
    {
        public void AddRole(Role r)
        {
            RoleDAO.AddRole(r);
        }

        public void DeleteRole(Role r)
        {
            RoleDAO.DeleteRole(r);
        }

        public Role FindRoleById(int id)
        {
            return RoleDAO.FindRoleById(id);
        }

        public List<Role> GetRoles()
        {
            return RoleDAO.GetRoles();
        }

        public void UpdateRole(Role r)
        {
            RoleDAO.UpdateRole(r);
        }
    }
}
