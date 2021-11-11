﻿using Payroll.Models;
using System.IO;

namespace Payroll.Services
{
    public class Seeder
    {
        public static void Seed()
        {
            var input = File.ReadAllLines(Database.FilePath);
            
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

                    Database.Accounts.Add(account);
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

                    Database.Accounts.Add(account);
                }
            }

            if (Database.Accounts.Count < 1)
            {
                var admin = new Admin { Id = 1, Username = "admin1", Password = "admin1234", Salary = 50000, Role = "Cheif Excecutive Officer" };
                Database.Accounts.Add(admin);
                var content = new string[] { $"{admin.Id},{admin.Username},{admin.Password},{admin.Salary},{admin.Role},{admin.IsAdmin}," };
                File.WriteAllLines(Database.FilePath, content);
            }
        }
    }
}
