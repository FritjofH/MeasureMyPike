using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using System;
using MeasureMyPike.Models.Application;
using System.Collections.Generic;

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

        private Catch CreateOneCatch()
        {
            return cs.AddCatch(ms.ImageToByteArray(theImage), ms.GetImageFormat(theImage), "Min enorma gädda", theLure, "75 kg", "300cm (mellan ögonen)", theLake.Name, "xy", 22, "Soligt", theUser.Username);
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void AddOneCatch()
        {
            // we need some base data
            CreatePredefined();

            // Create the actual catch
            theCatch = CreateOneCatch();

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            // remove the catch
            Assert.IsTrue(cs.DeleteCatch(theCatch.Id), "Kan inte radera testCatch med Id=" + theCatch.Id);

            // cleanup the rest
            CleanupPredefined();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void GetOneCatch()
        {
            // we need some base data
            CreatePredefined();

            // Create the actual catch
            theCatch = CreateOneCatch();

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            Catch oneCatch = cs.GetCatch(theCatch.Id);

            Assert.IsNotNull(oneCatch, "Kunde inte hämta en Catch");

            Assert.AreEqual(theCatch.UserId, oneCatch.UserId, "User skiljer sig åt");
            Assert.AreEqual(theCatch.Timestamp.ToString(), oneCatch.Timestamp.ToString(), "Timestamp skiljer sig åt");
            Assert.AreEqual(theCatch.LocationId, oneCatch.LocationId, "Location skiljer sig åt");
            Assert.AreEqual(theCatch.FishId, oneCatch.FishId, "Fish skiljer sig åt");
            Assert.AreEqual(theCatch.WeatherData.ToString(), oneCatch.WeatherData.ToString(), "WeatherData skiljer sig åt");

            // remove the catch
            Assert.IsTrue(cs.DeleteCatch(theCatch.Id), "Kan inte radera testCatch med Id=" + theCatch.Id);

            // cleanup the rest
            CleanupPredefined();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void GetAllCatches()
        {
            // we need some base data
            CreatePredefined();

            // get current list of catches
            List<Catch> orgListOfCatches = cs.GetAllCatches();
            Assert.IsNotNull(orgListOfCatches, "Kunde inte hämta en Catches");

            // Create one catch
            theCatch = CreateOneCatch();

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            List<Catch> listOfCatches = cs.GetAllCatches();

            Assert.IsNotNull(listOfCatches, "Kunde inte hämta listan av Catches");
            Assert.AreEqual(orgListOfCatches.Count+1, listOfCatches.Count, "Listan innehöll inte rätt antal Catches");

            // locate our newly created catch
            Catch newCatch = listOfCatches.Find(c => c.Id == theCatch.Id);
            Assert.IsNotNull(newCatch, "Kunde inte hitta vår nya Catche");

            Assert.AreEqual(theCatch.UserId, newCatch.UserId, "User skiljer sig åt");
            Assert.AreEqual(theCatch.Timestamp.ToString(), newCatch.Timestamp.ToString(), "Timestamp skiljer sig åt");
            Assert.AreEqual(theCatch.LocationId, newCatch.LocationId, "Location skiljer sig åt");
            Assert.AreEqual(theCatch.FishId, newCatch.FishId, "Fish skiljer sig åt");
            Assert.AreEqual(theCatch.WeatherData.ToString(), newCatch.WeatherData.ToString(), "WeatherData skiljer sig åt");

            // remove the catch
            Assert.IsTrue(cs.DeleteCatch(theCatch.Id), "Kan inte radera testCatch med Id=" + theCatch.Id);

            // cleanup the rest
            CleanupPredefined();
        }
    }
}
