using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1
{
    [TestClass]
    public class PasswordSecurityTests
    {
        [TestMethod]
        public void CheckPassword123Levels()
        {
            string Password = "hhhhhhhh";
            PasswordSecurity de = new PasswordSecurity();
            int u = de.CheckPassword(Password);
            Assert.AreEqual(1, u);
        }
    }
}
