using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Controllers;
using Payroll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        [TestMethod()]
        [DataRow("admin1", "admin1234", true)]
        [DataRow("admin1", "admin123", false)]
        [DataRow("admin", "admin1234", false)]
        [DataRow("", "admin1234", false)]
        [DataRow("admin1", "", false)]
        [DataRow(null, "admin1234", false)]
        [DataRow("admin1", null, false)]
        public void LoginTest(string username, string password, bool expected)
        {
            var loginController = new LoginController();
            var actual = loginController.Login(username, password);
            Assert.AreEqual(expected, actual);
        }
    }
}