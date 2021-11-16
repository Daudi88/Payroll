using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        Database db;
        AccountController accountController;
        User validUser;
        User invalidUsername;
        User existingUsername;
        User invalidPassword;

        [TestInitialize]
        public void Initialize()
        {
            db = new Database();
            accountController = new AccountController();
            validUser = new User { Id = 2, Username = "user1", Password = "user1234" };
            invalidUsername = new User { Username = "user", Password = "password1" };
            invalidPassword = new User { Username = "user4", Password = "password" };
            existingUsername = new User { Username = "admin1" };
        }

        [TestMethod()]
        public void AddAndRemoveTest_ValidUser_ReturnsTrue()
        {
            var actual = accountController.Add(db, validUser);
            Assert.IsTrue(actual);
            actual = accountController.Remove(db, validUser);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void AddTest_InvalidUsername_ReturnsFalse()
        {
            var actual = accountController.Add(db, invalidUsername);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_InvalidPassword_ReturnsFalse()
        {
            var actual = accountController.Add(db, invalidPassword);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void AddTest_ExistingUser_ReturnsFalse()
        {
            var actual = accountController.Add(db, existingUsername);
            Assert.IsFalse(actual);
        }
    }
}