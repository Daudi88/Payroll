using Payroll.Models;
using Payroll.Services;
using System;
using static Payroll.Helpers.Helper;

namespace Payroll.Views
{
    class AdminView
    {
        public static void Menu(Database db, Admin admin)
        {
            var logout = false;
            while (!logout)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check current payroll");
                Console.WriteLine("2. See role in company");
                Console.WriteLine("3. List all users");
                Console.WriteLine("4. Add a new account");
                Console.WriteLine("5. Remove an account");
                Console.WriteLine("6. Logout");

                Console.Write("> ");

                if (int.TryParse(GetInput(), out var userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            AccountView.PrintPayroll(admin);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            AccountView.Add(db);
                            break;
                        case 5:
                            AccountView.RemoveAnAccount(db, admin);
                            break;
                        case 6:
                            logout = true;
                            break;
                        default:
                            ErrorMessage("None available option, try a number between 1-6");
                            break;
                    }
                }
                else
                {
                    ErrorMessage("Wrong type of input, only numbers please");
                }
            }
        }
    }
}
