using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class AccountRepository : IAccountRepository
    {
        public void AddAccount(Account acc)
        {
            AccountDAO.AddAccount(acc);
        }

        public void DeleteAccount(Account acc)
        {
            AccountDAO.DeleteAccount(acc);
        }

        public Account FindAccountByEmail(string email)
        {
            return AccountDAO.FindAccountByEmail(email);
        }

        public Account FindAccountById(int id)
        {
            return AccountDAO.FindAccountById(id);
        }

        public List<Account> GetAccounts()
        {
            return AccountDAO.GetAccounts();
        }

        public List<Account> SearchAccount(string keyword)
        {
            return AccountDAO.SearchAccount(keyword);
        }

        public void UpdateAccount(Account acc)
        {
            AccountDAO.UpdateAccount(acc);
        }
    }
}
