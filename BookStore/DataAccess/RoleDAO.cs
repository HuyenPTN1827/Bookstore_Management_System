﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var listRoles = new List<Role>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listRoles = context.Roles.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listRoles;
        }

        public static Role FindRoleById(int roleId)
        {
            var Role = new Role();
            try
            {
                using (var context = new BookStoreContext())
                {
                    Role = context.Roles.SingleOrDefault(x => x.RoleId == roleId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Role;
        }

        public static void AddRole(Role role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateRole(Role role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Role>(role).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRole(Role role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Roles
                        .SingleOrDefault(x => x.RoleId == role.RoleId);
                    context.Roles.Remove(temp);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
