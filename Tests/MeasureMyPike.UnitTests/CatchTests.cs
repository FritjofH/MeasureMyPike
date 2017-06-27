using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using System;

namespace ApplicationTest
{
    [TestClass]
    public class CatchTests
    {
        ICatchService cs;
        IMediaService ms;
        IBrandService bs;
        ILureService ls;
        IUserService us;

        [TestInitialize]
        public void Initialize()
        {
            cs = new CatchService();
            ms = new MediaService();
            bs = new BrandService();
            ls = new LureService();
            us = new UserService();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void CreateCatch()
        {
            var rnd = new Random();

            //Fiskbild och konverting till en bytearray
            Image testImage = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");
            string lureName = "testLure" + rnd.Next(0,99);
            string brandName = "testBrand" + rnd.Next(0,99);
            int weight = 24;
            string color = "Red";
            string fnamn = "Förnamn" + rnd.Next(0, 99);
            string enamn = "Efternamn" + rnd.Next(0, 99);
            string userName = "testUser" + rnd.Next(0, 99);
            string pass = "hemligt";
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var createdUser = us.CreateUser(enamn, fnamn, userName, pass);

            Assert.IsNotNull(createdUser, "Kan inte skapa testUser "+userName);

            var createdBrand = bs.AddBrand(brandName);

            Assert.IsNotNull(createdBrand, "Kunde inte skapa Brand "+brandName);

            int brandId = createdBrand.Id;
            var createdLure = ls.AddLure(lureName, createdBrand.Id, weight, color);

            Assert.IsNotNull(createdLure, "Kunde inte skapa Lure "+lureName);

            int lureId = createdLure.Id;
            var createdCatch = cs.AddCatch(ms.ImageToByteArray(testImage), ms.GetImageFormat(testImage), "Jag fångade en fisk", createdLure, "75 kg", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", userName);

            Assert.IsNotNull(createdCatch, "Något gick fel vid skapandet av fångsten");

            int catchId = createdCatch.Id;

            // cleanup
            Assert.IsTrue(cs.DeleteCatch(catchId), "Kan inte radera testCatch "+createdCatch);
            Assert.IsTrue(ls.DeleteLure(lureId), "Kan inte radera testLure "+lureName);
            Assert.IsTrue(bs.DeleteBrand(brandId), "Kan inte radera testBrand "+brandName);
            Assert.IsTrue(us.DeleteUser(userName), "Kan inte radera testUser "+userName);
        }
    }
}
