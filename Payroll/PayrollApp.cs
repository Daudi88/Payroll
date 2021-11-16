using Payroll.Services;
using Payroll.Views;

namespace Payroll
{
    class PayrollApp
    {
        public void Start()
        {
            var db = new Database();
            var seeder = new Seeder();
            seeder.Seed(db);
            LoginView.Menu(db);
        }
    }
}
