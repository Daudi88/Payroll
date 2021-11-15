using Payroll.Controllers;
using Payroll.Models;
using Payroll.Services;
using System;
using static Payroll.Helpers.Helper;

namespace Payroll.Views
{
    class LoginView
    {
        public static void Login(Database db)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter username: ");
                var username = GetInput();
                Console.Write("Enter password: ");
                var password = GetInput();

                var loginController = new LoginController();
                var account = loginController.Login(db, username, password);
                if (account != null)
                {
                    SuccessMessage("Login was successfull!");
                    if (account.IsAdmin)
                    {
                        var admin = (Admin)account;
                        AdminView.Menu(db, admin);
                    }
                    else
                    {
                        var user = (User)account;
                        UserView.Menu(db, user);
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
