using Payroll.Models;
using System;
using static Payroll.Helpers.Helper;

namespace Payroll.Views
{
    class UserView
    {
        public static void Menu(Account user)
        {
            var logout = false;
            while (!logout)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check current payroll");
                Console.WriteLine("2. See role in company");
                Console.WriteLine("3. Remove account");
                Console.WriteLine("4. Logout");

                Console.Write("> ");

                if (int.TryParse(GetInput(), out var userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            logout = true;
                            break;
                        default:
                            ErrorMessage("None available option, try a number between 1-4");
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
