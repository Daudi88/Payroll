using Payroll.Models;

namespace Payroll.Services
{
    public class Seeder
    {
        public void Seed(Database db)
        {
            db.Load();

            if (db.Accounts.Count < 1)
            {
                var admin = new Admin { Id = 1, Username = "admin1", Password = "admin1234", Salary = 50000, Role = "Cheif Excecutive Officer" };
                db.Accounts.Add(admin);
                db.Save();
            }
        }
    }
}
