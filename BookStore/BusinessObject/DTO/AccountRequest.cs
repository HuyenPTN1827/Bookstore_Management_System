using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class AccountRequest
    {
        public AccountRequest()
        {
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int RoleId { get; set; }
    }
}
