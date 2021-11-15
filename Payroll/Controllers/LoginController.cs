using Payroll.Models;
using Payroll.Services;
using System.Linq;

namespace Payroll.Controllers
{
    public class LoginController
    {
        public Account Login(Database db, string username, string password)
        {
            return db.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}
