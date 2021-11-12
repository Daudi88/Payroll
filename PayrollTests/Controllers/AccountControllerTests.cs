using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Controllers;
using Payroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        User validUser;
        User invalidUser;
        User existingUsername;
        AccountController accountCont;

        [TestInitialize]
        public void Initialize()
        {
            validUser = new User {Username = "user1", Password = "user1234" };
            invalidUser = new User {Username = "   " };
            existingUsername = new User { Username = "admin1" };
            accountCont = new AccountController();
        }

        [TestMethod()]
        public void AddAndRemoveTest_ValidUser_ReturnsTrue()
        {
            var actual1 = accountCont.Add(validUser);
            Assert.IsTrue(actual1);
            var actual2 = accountCont.Remove(validUser);
            Assert.IsTrue(actual2);
        }

        [TestMethod()]
        public void AddTest_InvalidUser_ReturnsFalse()
        {
            var actual = accountCont.Add(invalidUser);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_ExistingUser_ReturnsFalse()
        {
            var actual = accountCont.Add(existingUsername);
            Assert.IsFalse(actual);
        }
    }
}