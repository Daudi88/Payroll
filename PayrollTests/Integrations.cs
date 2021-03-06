using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Controllers;
using Payroll.Models;
using Payroll.Services;

namespace PayrollTests
{
    [TestClass()]
    public class Integrations
    {
        Database db;
        AccountController accountController;
        LoginController loginController;

        [TestInitialize]
        public void Intitialize()
        {
            db = new();
            accountController = new();
            loginController = new();

            var admin = new Admin { Username = "admin1", Password = "admin1234" };
            db.Accounts.Add(admin);
            var user = new User { Username = "user1", Password = "pass1" };
            db.Accounts.Add(user);
        }


        [TestMethod()]
        public void Integration_AdminFlow_ReturnsTrue()
        {
            var admin = loginController.Login(db, "admin1", "admin1234");
            var user = new User { Username = "user23", Password = "pass1234" };
            accountController.Add(db, user);
            var (account, _) = accountController.RemoveChecks(db, (Admin)admin, user.Username, user.Password);
            var actual = accountController.Remove(db, account);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void Integration_AdminRemoveSelf_ReturnsFalse()
        {
            var admin = loginController.Login(db, "admin1", "admin1234");
            var (account, _) = accountController.RemoveChecks(db, (Admin)admin, admin.Username, admin.Password);
            var actual = accountController.Remove(db, account);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Integration_UserRemoveSelf_ReturnsTrue()
        {
            var user = loginController.Login(db, "user1", "pass1");
            var actual = accountController.Remove(db, user);
            Assert.IsTrue(actual);
        }
    }
}
