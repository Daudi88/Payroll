using Payroll.Controllers;
using Payroll.Models;
using Payroll.Services;
using System;
using System.Linq;
using static Payroll.Helpers.Helper;

namespace Payroll.Views
{
    class AccountView
    {
        public static void Add(Database db)
        {
            Account account;

            Console.Write("Would you like the new account to be an Admin [1] or User [2]? ");
            int.TryParse(GetInput(), out int choice);
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

            Console.WriteLine("Please enter the following for the new account:");
            Console.Write("Username: ");
            account.Username = GetInput();
            Console.Write("Password: ");
            account.Password = GetInput();
            Console.Write("Company role: ");
            account.Role = GetInput();
            Console.Write("Salary: ");
            int.TryParse(GetInput(), out var salary);
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

        public static void PrintPayroll(Account account)
        {
            if (account == null)
            {
                return;
            }

            if (account.Salary > 0)
            {
                Console.Write($"Your next payroll is: ");
                SuccessMessage(string.Format($"{account.Salary:C}"));
            }
            else
            {
                ErrorMessage("The salary for your account isn't set yet.");
            }
        }

        public static void RemoveAnAccount(Database db, Admin admin)
        {
            Console.WriteLine("Please enter the following for the account to remove: ");
            Console.Write("Username: ");
            var username = GetInput();
            Console.Write("Password: ");
            var password = GetInput();

            var accountController = new AccountController();
            var (account, message) = accountController.RemoveChecks(db, admin, username, password);
            if(account != null)
            {
                RemoveAccount(db, account);
            }
            else
            {
                ErrorMessage(message);
            }

        }

        public static bool RemoveAccount(Database db, Account account)
        {
            if(account == null)
            {
                return false;
            }

            Console.WriteLine($"Are you sure that you'd like to remove {account.Username}?");
            Console.WriteLine("Enter [remove] to remove the account, press any key to abort");
            Console.Write("> ");
            var input = GetInput();
            if(input == "remove")
            {
                var accountCont = new AccountController();
                if(accountCont.Remove(db, account))
                {
                    SuccessMessage($"{account.Username} is successfully removed");
                    return true;
                }
                else
                {
                    ErrorMessage("Something went wrong");
                }
            }
            else
            {
                ErrorMessage($"{account.Username} was not removed");
            }

            return false;
        }
    }
}
