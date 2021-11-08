using Microsoft.EntityFrameworkCore;
using Payroll.Models;

namespace Payroll.Services
{
    public class PayrollContext : DbContext
    {
        public string DatabaseName { get; set; } = "PayrollDb";

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ($@"Server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection=True;");
        }
    }
}
