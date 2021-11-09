using Payroll.Models;
using System.Collections.Generic;
using System.Linq;

namespace Payroll.Services
{
    class Seeder
    {
        public static void Seed()
        {
            using var db = new PayrollContext();
            if (!db.Roles.Any())
            {
                db.Roles.AddRange(new List<Role>
                {
                    new Role{Description="Cheif Excecutive Officer"},
                    new Role{Description="Cheif Technology Officer"},
                    new Role{Description="Marketing Manager"},
                    new Role{Description="Product Manager"},
                    new Role{Description="Project Manager"},
                    new Role{Description="Business Analyst"},
                    new Role{Description="Software Engineer"},
                    new Role{Description="Fullstack Developer"},

                });

                db.SaveChanges();
            }

            if (!db.Accounts.Any())
            {
                db.Accounts.Add(new Admin { Username = "admin1", Password = "admin1234", Role = db.Roles.FirstOrDefault(r => r.Description == "Cheif Excecutive Officer"), Salary = 50000});
                db.SaveChanges();
            }
        }
    }
}
