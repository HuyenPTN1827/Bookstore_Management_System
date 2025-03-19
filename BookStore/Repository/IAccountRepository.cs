using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        List<Account> SearchAccount(string keyword);
        Account FindAccountById(int id);
        Account FindAccountByEmail(string email);
        void AddAccount(Account acc);
        void UpdateAccount(Account acc);
        void DeleteAccount(Account acc);
    }
}
