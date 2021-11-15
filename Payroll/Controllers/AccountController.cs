using Payroll.Models;
using Payroll.Services;
using System.Linq;
using static Payroll.Helpers.Helper;

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

        public Account RemoveChecks(Database db, Admin admin, string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(u => u.Username == username);
            if (account != null)
            {
                if (account.Password == password)
                {
                    if (account.Id != admin.Id)
                    {
                        return account;
                    }
                    else
                    {
                        ErrorMessage("You cannot remove your own account as admin");
                    }
                }
                else
                {
                    ErrorMessage("Password is incorrect");
                }
            }
            else
            {
                ErrorMessage("There's no account matching the username provided");
            }

            return null;
        }

        public bool Remove(Database db, Account account)
        {
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
