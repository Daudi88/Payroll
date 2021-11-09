using Payroll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Controllers
{
    public class LoginController
    {
        public bool Login(string username, string password)
        {
            var db = new PayrollContext();
            var account = db.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (account != null)
            {
                return true;
            }

            return false;
        }
    }
}
