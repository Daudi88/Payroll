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
        }


        [TestMethod()]
        public void Integration_AdminFlow_ReturnsTrue()
        {
            var admin = loginController.Login(db, "admin1", "admin1234");
            var user = new User { Username = "user23", Password = "pass1234" };
            accountController.Add(db, user);
            var (account, message) = accountController.RemoveChecks(db, (Admin)admin, user.Username, user.Password);
            var actual = accountController.Remove(db, account);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void Integration_AdminRemoveSelf_ReturnsFalse()
        {
            var admin = loginController.Login(db, "admin1", "admin1234");
            var (account, message) = accountController.RemoveChecks(db, (Admin)admin, admin.Username, admin.Password);
            var actual = accountController.Remove(db, account);
            Assert.IsFalse(actual);
        }
    }
}
