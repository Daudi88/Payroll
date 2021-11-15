using Payroll.Controllers;
using Payroll.Models;
using Payroll.Services;
using System;
using static Payroll.Helpers.Helper;

namespace Payroll.Views
{
    class AccountView
    {
        public static void Add(Database db)
        {
            Account account;

            Console.Write("Would you like the new account to be an Admin [1] or User [2]? ");
            int.TryParse(Console.ReadLine(), out int choice);
            if(choice == 1)
            {
                account = new Admin();
            }
            else if(choice == 2)
            {
                account = new User();
            }
            else
            {
                ErrorMessage("None valid option, you will be returned to main menu");
                return;
            }

            account.Id = db.Accounts.Count + 1;
            Console.WriteLine("Please enter the following for the new account:");
            Console.Write("Username: ");
            account.Username = Console.ReadLine();
            Console.Write("Password: ");
            account.Password = Console.ReadLine();
            Console.Write("Company role: ");
            account.Role = Console.ReadLine();
            Console.Write("Salary: ");
            int.TryParse(Console.ReadLine(), out var salary);
            account.Salary = salary;

            AccountController accountCont = new();
            if (accountCont.Add(db, account))
            {
                SuccessMessage("The new account was successfully added!");
            }
            else
            {
                ErrorMessage("Something went wrong." +
                    "\nMake sure to create a unique username. " +
                    "\nRemember that username and password need to contain digits and letters");
            }
            
        }
    }
}
