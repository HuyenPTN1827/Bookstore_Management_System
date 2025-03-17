using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        public static List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listAccounts = context.Accounts.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAccounts;
        }

        public static List<Account> SearchAccount(string keyword)
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listAccounts = context.Accounts
                        .Where(x => x.Username.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Fullname.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Email.ToLower().Trim().Contains(keyword.ToLower().Trim()))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAccounts;
        }

        public static Account FindAccountById(int id)
        {
            var account = new Account();
            try
            {
                using (var context = new BookStoreContext())
                {
                    account = context.Accounts.SingleOrDefault(x => x.AccountId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public static Account FindAccountByEmail(string email)
        {
            var account = new Account();
            try
            {
                using (var context = new BookStoreContext())
                {
                    account = context.Accounts
                        .SingleOrDefault(x => x.Email.ToLower().Trim().Equals(email.ToLower().Trim()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public static void AddAccount(Account account)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAccount(Account account)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Account>(account).State = 
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAccount(Account account)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Accounts
                        .SingleOrDefault(x => x.AccountId == account.AccountId);
                    context.Accounts.Remove(temp);
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
