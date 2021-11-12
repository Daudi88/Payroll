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
        User invalidUsername;
        User existingUsername;
        User invalidPassword;
        AccountController accountCont;

        [TestInitialize]
        public void Initialize()
        {
            validUser = new User {Username = "user1", Password = "user1234" };
            invalidUsername = new User {Username = "user", Password = "password1"};
            invalidPassword = new User { Username = "user4", Password = "password"};
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
        public void AddTest_InvalidUsername_ReturnsFalse()
        {
            var actual = accountCont.Add(invalidUsername);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_InvalidPassword_ReturnsFalse()
        {
            var actual = accountCont.Add(invalidPassword);
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