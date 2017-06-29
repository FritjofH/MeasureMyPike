using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using System;
using MeasureMyPike.Models.Application;

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
        ILakeService lks;

        Lure theLure;
        Brand theBrand;
        User theUser;
        Lake theLake;
        Catch theCatch;
        Image theImage;

        [TestInitialize]
        public void Initialize()
        {
            cs = new CatchService();
            ms = new MediaService();
            bs = new BrandService();
            ls = new LureService();
            us = new UserService();
            lks = new LakeService();
        }

        private void CreatePredefined()
        {
            var rnd = new Random();

            int lureWeight = 24;
            string lureColor = "Red";
            string lureName = "testLure" + rnd.Next(0, 999);
            string brandName = "testBrand" + rnd.Next(0, 999);
            string fnamn = "Förnamn" + rnd.Next(0, 999);
            string enamn = "Efternamn" + rnd.Next(0, 999);
            string userName = "testUser" + rnd.Next(0, 999);
            string pass = "hemligt";
            string lakeName = "testSjö" + rnd.Next(0, 999);
            //Fiskbild och konverting till en bytearray
            theImage = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");

            // Setup of needed predefined data
            theUser = us.CreateUser(enamn, fnamn, userName, pass);
            Assert.IsNotNull(theUser, "Kunde inte skapa testUser " + userName);
            theBrand = bs.AddBrand(brandName);
            Assert.IsNotNull(theBrand, "Kunde inte skapa testBrand " + brandName);
            theLure = ls.AddLure(lureName, theBrand.Id, lureWeight, lureColor);
            Assert.IsNotNull(theLure, "Kunde inte skapa testLure " + lureName);
            theLake = lks.AddLake(lakeName);
            Assert.IsNotNull(theLake, "Kunde inte skapa testLake " + lakeName);
        }

        private void CleanupPredefined()
        {
            // cleanup of predefined data
            Assert.IsTrue(ls.DeleteLure(theLure.Id), "Kan inte radera testLure " + theLure.Name);
            Assert.IsTrue(bs.DeleteBrand(theBrand.Id), "Kan inte radera testBrand " + theBrand.Name);
            Assert.IsTrue(us.DeleteUser(theUser.Id), "Kan inte radera testUser " + theUser.Username);
            Assert.IsTrue(lks.DeleteLake(theLake.Id), "Kan inte radera testLake " + theLake.Name);
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void AddOneCatch()
        {
            CreatePredefined();

            // Create the actual catch
            theCatch = cs.AddCatch(ms.ImageToByteArray(theImage), ms.GetImageFormat(theImage), "Min enorma gädda", theLure, "75 kg", "300cm (mellan ögonen)", theLake.Name, "xy", 22, "Soligt", theUser.Username);

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            // remove the catch
            Assert.IsTrue(cs.DeleteCatch(theCatch.Id), "Kan inte radera testCatch med Id=" + theCatch.Id);

            CleanupPredefined();
        }
    }
}
