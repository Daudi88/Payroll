using Payroll.Models;
using Payroll.Services;
using System.Linq;

namespace Payroll.Controllers
{
    public class AccountController
    {
        public bool Add(Database db, Account newAccount)
        {
            if(!string.IsNullOrEmpty(newAccount.Username) 
                && newAccount.Username.Any(char.IsDigit) 
                && newAccount.Username.Any(char.IsLetter))
            {
                foreach(var account in db.Accounts)
                {
                    if(newAccount.Username == account.Username)
                    {
                        return false;
                    }
                }

                if(!string.IsNullOrEmpty(newAccount.Password)
                    && newAccount.Password.Any(char.IsDigit)
                    && newAccount.Password.Any(char.IsLetter))
                {
                    newAccount.Id = db.Accounts.Count + 1;
                    db.Accounts.Add(newAccount);
                    db.Save();
                    return true;
                }
            }

            return false;
        }

        public (Account, string) RemoveChecks(Database db, Admin admin, string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(u => u.Username == username);
            string message = null;
            if (account != null)
            {
                if (account.Password == password)
                {
                    if (account.Id != admin.Id)
                    {
                        return (account, message);
                    }
                    else
                    {
                        message = "You cannot remove your own account as admin";
                    }
                }
                else
                {
                    message = "Password is incorrect";
                }
            }
            else
            {
                message = "There's no account matching the username provided";
            }

            return (null, message);
        }

        public bool Remove(Database db, Account account)
        {
            if(account == null)
            {
                return false;
            }

            try
            {
                db.Accounts.Remove(account);
                db.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
