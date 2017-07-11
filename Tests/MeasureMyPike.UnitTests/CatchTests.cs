using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using System;
using MeasureMyPike.Models.Application;
using System.Collections.Generic;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class CatchTests
    {
        ICatchService cs;
        TestsCommon common;
        Catch theCatch;

        [TestInitialize]
        public void Initialize()
        {
            cs = new CatchService();
            common = new TestsCommon();

            // we need some base data
            common.GenerateTestData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // cleanup the testdata
            common.CleanupTestData();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void AddOneCatch()
        {
            // Create the actual catch
            theCatch = common.GenerateTestCatch();

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            // remove the catch
            common.CleanupTestCatch();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void GetOneCatch()
        {
            // Create the actual catch
            theCatch = common.GenerateTestCatch();

            Assert.IsNotNull(theCatch, "Kunde inte skapa testCatch");

            Catch oneCatch = cs.GetCatch(theCatch.Id);

            Assert.IsNotNull(oneCatch, "Kunde inte hämta en Catch");

            Assert.AreEqual(theCatch.UserId, oneCatch.UserId, "User skiljer sig åt");
            Assert.AreEqual(theCatch.Timestamp.ToString(), oneCatch.Timestamp.ToString(), "Timestamp skiljer sig åt");
            Assert.AreEqual(theCatch.LocationId, oneCatch.LocationId, "Location skiljer sig åt");
            Assert.AreEqual(theCatch.FishId, oneCatch.FishId, "Fish skiljer sig åt");
            Assert.AreEqual(theCatch.WeatherData.ToString(), oneCatch.WeatherData.ToString(), "WeatherData skiljer sig åt");

            // remove the catch
            Assert.IsTrue(common.CleanupTestCatch(), "Kan inte radera testCatch med Id=" + theCatch.Id);
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void GetAllCatches()
        {
            // get current list of catches
            List<Catch> orgListOfCatches = cs.GetAllCatches();
            Assert.IsNotNull(orgListOfCatches, "Kunde inte hämta en Catches");

            // Create one catch
            theCatch = common.GenerateTestCatch();

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
            Assert.IsTrue(common.CleanupTestCatch(), "Kan inte radera testCatch med Id=" + theCatch.Id);
        }
    }
}
