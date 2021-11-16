using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll.Models;
using Payroll.Services;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        Database db;
        LoginController loginController;
        Admin admin;

        [TestInitialize]
        public void Initialize()
        {
            db = new Database();
            loginController = new LoginController();
            admin = new Admin { Username = "admin1", Password = "admin1234" };
            db.Accounts.Add(admin);
        }

        [TestMethod()]
        public void LoginTest_CorrectInput_ReturnsAccount()
        {
            var account = loginController.Login(db, "admin1", "admin1234");
            Assert.IsNotNull(account);
        }

        [TestMethod()]
        [DataRow("admin1", "admin123")]
        [DataRow("admin", "admin1234")]
        [DataRow("", "admin1234")]
        [DataRow("admin1", "")]
        [DataRow(null, "admin1234")]
        [DataRow("admin1", null)]
        public void LoginTest_WrongInput_ReturnsNull(string username, string password)
        {
            var account = loginController.Login(db, username, password);
            Assert.IsNull(account);
        }
    }
}