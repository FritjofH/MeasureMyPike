using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;

namespace ApplicationTest
{
    [TestClass]
    public class UserTests
    {
        UserService us;
        SecurityService ss;

        [TestInitialize]
        public void Initialize()
        {
            us = new UserService();
            ss = new SecurityService();
        }

        [TestMethod]
        [TestCategory("UserTest")]
        public void createUser()
        {
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var result = us.CreateUser("Höst", "Fritjof", "hostf", "hemligt");
            Assert.IsTrue(result, "Det finns redan en användare med samma användarnamn");
        }

        [TestMethod]
        [TestCategory("UserTest")]
        public void loginUserSucceeds()
        {
            var result = ss.Login("hostf", "hemligt");
            Assert.IsTrue(result," Det angivna lösenordet matchade inte");
        }

        [TestMethod]
        [TestCategory("UserTest")]
        public void loginUserFails()
        {
            var result= ss.Login("hostf", "fel lösenord");
            Assert.IsFalse(result, "Det angivna lösenordet matchade");
        }
    }
}
