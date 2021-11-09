using Payroll.Services;
using Payroll.Views;
using System;

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
