using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.Collections.Generic;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class LakeTests
    {
        ILakeService lks;

        [TestInitialize]
        public void Initialize()
        {
            lks = new LakeService();
        }

        [TestMethod]
        [TestCategory("LakeTest")]
        public void CreateOneLake()
        {
            var rnd = new Random();
            string lakeName = "testSjön" + rnd.Next(0, 999);

            var result = lks.AddLake(lakeName);

            Assert.IsNotNull(result, "Kunde inte skapa sjön");

            // cleanup
            Assert.IsTrue(lks.DeleteLake(result.Id), "Could not delete lake with id " + result.Id);
        }

        [TestMethod]
        [TestCategory("LakeTest")]
        public void ChangeOneLake()
        {
            var rnd = new Random();
            string lakeName = "testSjön" + rnd.Next(0, 999);
            string newLakeName = "nytestSjö" + rnd.Next(0, 999);

            Lake result = lks.AddLake(lakeName);

            lks.UpdateLake(result.Id, newLakeName);
            Lake updated = lks.GetLake(result.Id);

            Assert.AreEqual(newLakeName, updated.Name, "Kunde inte byta namn på sjön");

            // cleanup
            Assert.IsTrue(lks.DeleteLake(updated.Id), "Could not delete lake with id " + updated.Id);
        }
    }
}
