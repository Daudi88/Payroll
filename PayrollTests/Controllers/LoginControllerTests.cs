using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Payroll.Controllers.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        [TestMethod()]
        public void LoginTest_CorrectInput_ReturnsAccount()
        {
            var loginController = new LoginController();
            var account = loginController.Login("admin1", "admin1234");
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
            var loginController = new LoginController();
            var account = loginController.Login(username, password);
            Assert.IsNull(account);
        }
    }
}