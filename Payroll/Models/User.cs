using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Models
{
    class User : Account
    {
        public User()
        {
            IsAdmin = false;
        }
    }
}
