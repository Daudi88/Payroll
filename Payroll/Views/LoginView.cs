using Payroll.Controllers;
using System;
using System.Threading;

namespace Payroll.Views
{
    class LoginView
    {
        public static void Run()
        {
            while (true)
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                var loginController = new LoginController();
                var account = loginController.Login(username, password);
                if (account != null)
                {
                    Console.WriteLine("Login was successfull!");
                    Thread.Sleep(2000);
                    if (account.IsAdmin)
                    {
                        // Admin menu
                    }
                    else
                    {
                        // User menu
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Login was not successfull!");
                    Console.WriteLine("Username or password was incorrect.");
                    Console.Write("Do you want to try again [y] or exit [n]?");
                    var choice = Console.ReadLine().ToLower();
                    if (choice == "n")
                    {
                        break;
                    }
                } 
            }
        }
    }
}
