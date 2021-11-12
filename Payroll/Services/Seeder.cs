using Payroll.Models;
using System.IO;

namespace Payroll.Services
{
    public class Seeder
    {
        public static void Seed()
        {
            Database.Load();

            if (Database.Accounts.Count < 1)
            {
                var admin = new Admin { Id = 1, Username = "admin1", Password = "admin1234", Salary = 50000, Role = "Cheif Excecutive Officer" };
                Database.Accounts.Add(admin);
                Database.Save();
            }
        }
    }
}
