using Payroll.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services
{
    public class Database
    {
        public static List<Account> Accounts = new();
        public static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.txt");

        public static void Load()
        {
            var input = File.ReadAllLines(FilePath);

            foreach (var line in input)
            {
                var inputLine = line.Split(',');

                // Checks IsAdmin to determine what type of account to create.
                if (inputLine[5] == "true")
                {
                    var account = new Admin
                    {
                        Id = int.Parse(inputLine[0]),
                        Username = inputLine[1],
                        Password = inputLine[2],
                        Salary = int.Parse(inputLine[3]),
                        Role = inputLine[4],
                    };

                    Accounts.Add(account);
                }
                else
                {
                    var account = new User
                    {
                        Id = int.Parse(inputLine[0]),
                        Username = inputLine[1],
                        Password = inputLine[2],
                        Salary = int.Parse(inputLine[3]),
                        Role = inputLine[4],
                    };

                    Accounts.Add(account);
                }
            }
        }

        public static void Save()
        {
            var contents = new string[Accounts.Count];
            for(int i = 0; i < contents.Length; i++)
            {
                var account = Accounts[i];
                contents[i] = $"{account.Id},{account.Username},{account.Password},{account.Salary},{account.Role},{account.IsAdmin}";
            }

            File.WriteAllLines(FilePath, contents);
        }
    }
}
