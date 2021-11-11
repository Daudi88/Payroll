using Payroll.Models;
using Payroll.Services;
using System.Linq;

namespace Payroll.Controllers
{
    public class LoginController
    {
        public Account Login(string username, string password)
        {
            return Seeder.Accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}
