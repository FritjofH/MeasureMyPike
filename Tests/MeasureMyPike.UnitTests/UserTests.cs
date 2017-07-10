using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System;

namespace MeasureMyPike.Tests
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
        public void CreateUser()
        {
            var rnd = new Random();
            string enamn = "Efternamn" + rnd.Next(1, 99);
            string userid = "useridc" + rnd.Next(1, 99);
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var result = us.CreateUser(enamn, "Förnamn", userid, "hemligt");

            Assert.IsNotNull(result, "Kunde inte skapa användare " + userid);
            
            //cleanup
            Assert.IsTrue(us.DeleteUser(userid),"Kan inte radera användare "+userid);
        }

        [TestMethod]
        [TestCategory("UserTest")]
        public void LoginUser()
        {
            var rnd = new Random();
            string fnamn = "Förnamn" + rnd.Next(0, 99);
            string enamn = "Efternamn" + rnd.Next(0, 99);
            string userid = "useridl" + rnd.Next(0, 99);
            string pass = "hemligt";
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var result = us.CreateUser(enamn, fnamn, userid, pass);

            Assert.IsNotNull(result, "Kunde inte skapa tillfällig användare "+userid);

            var loginResult = ss.Login(userid, pass);
            Assert.IsNotNull(loginResult,"Det gick inte logga in med korrekt lösenord");

            //cleanup
            Assert.IsTrue(us.DeleteUser(userid), "Kan inte radera tillfällig användare " + userid);
        }

        [TestMethod]
        [TestCategory("UserTest")]
        public void LoginUserWrongPassword()
        {
            var rnd = new Random();
            string fnamn = "Förnamn" + rnd.Next(0, 99);
            string enamn = "Efternamn" + rnd.Next(0, 99);
            string userid = "useridw" + rnd.Next(0, 99);
            string pass = "hemligt";
            string felpass = "fel lösenord";
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var result = us.CreateUser(enamn, fnamn, userid, pass);

            Assert.IsNotNull(result, "Kunde inte skapa tillfällig användare " + userid);

            var loginResult = ss.Login(userid, felpass);
            Assert.IsNotNull(loginResult, "Det gick logga in med fel lösenord");

            //cleanup
            Assert.IsTrue(us.DeleteUser(userid), "Kan inte radera tillfällig användare " + userid);
        }
    }
}
