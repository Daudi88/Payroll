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
                    db.Accounts.Add(newAccount);
                    db.Save();
                    return true;
                }
            }

            return false;
        }

        public bool Remove(Database db, Account account)
        {
            try
            {
                db.Accounts.Remove(account);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
