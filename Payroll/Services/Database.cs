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
    }
}
