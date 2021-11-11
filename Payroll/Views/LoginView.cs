using Payroll.Controllers;
using static Payroll.Helpers.Helper;
using System;

namespace Payroll.Views
{
    class LoginView
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter username: ");
                var username = GetInput();
                Console.Write("Enter password: ");
                var password = GetInput();

                var loginController = new LoginController();
                var account = loginController.Login(username, password);
                if (account != null)
                {
                    SuccessMessage("Login was successfull!");
                    if (account.IsAdmin)
                    {
                        AdminView.Menu(account);
                    }
                    else
                    {
                        UserView.Menu(account);
                    }

                    break;
                }
                else
                {
                    ErrorMessage("Login was not successfull!\nUsername or password was incorrect.");
                    Console.Write("Do you want to try again [y] or exit [n]? ");
                    var choice = GetInput().ToLower();
                    if (choice == "n")
                    {
                        break;
                    }
                } 
            }
        }
    }
}
