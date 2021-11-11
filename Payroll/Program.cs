using Payroll.Services;
using Payroll.Views;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            LoginView.Run();
        }
    }
}
