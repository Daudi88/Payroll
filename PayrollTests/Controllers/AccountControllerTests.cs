using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        Database db;
        User validUser;
        User invalidUsername;
        User existingUsername;
        User invalidPassword;
        AccountController accountCont;

        [TestInitialize]
        public void Initialize()
        {
            db = new Database();
            validUser = new User {Username = "user1", Password = "user1234" };
            invalidUsername = new User {Username = "user", Password = "password1"};
            invalidPassword = new User { Username = "user4", Password = "password"};
            existingUsername = new User { Username = "admin1" };
            accountCont = new AccountController();
        }

        [TestMethod()]
        public void AddAndRemoveTest_ValidUser_ReturnsTrue()
        {
            var actual1 = accountCont.Add(db, validUser);
            Assert.IsTrue(actual1);
            var actual2 = accountCont.Remove(db, validUser);
            Assert.IsTrue(actual2);
        }

        [TestMethod()]
        public void AddTest_InvalidUsername_ReturnsFalse()
        {
            var actual = accountCont.Add(db, invalidUsername);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_InvalidPassword_ReturnsFalse()
        {
            var actual = accountCont.Add(db, invalidPassword);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_ExistingUser_ReturnsFalse()
        {
            var actual = accountCont.Add(db, existingUsername);
            Assert.IsFalse(actual);
        }
    }
}