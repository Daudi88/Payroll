using Payroll.Models;
using Payroll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class AccountController
    {
        public bool Add(Account newAccount)
        {
            if(!string.IsNullOrEmpty(newAccount.Username))
            {
                foreach(var account in Database.Accounts)
                {
                    if(newAccount.Username == account.Username)
                    {
                        return false;
                    }
                }

                if(!string.IsNullOrEmpty(newAccount.Password))
                {
                    Database.Accounts.Add(newAccount);
                    Database.Save();
                    return true;
                }
            }

            return false;
        }

        public bool Remove(Account account)
        {
            try
            {
                Database.Accounts.Remove(account);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
