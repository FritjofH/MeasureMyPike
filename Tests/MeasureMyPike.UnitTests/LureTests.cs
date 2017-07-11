using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class LureTests
    {        
        LureService ls;
        BrandService bs;
        Brand testBrand;

        [TestInitialize]
        public void Initialize()
        {
            ls = new LureService();
            bs = new BrandService();

            testBrand = bs.AddBrand("testBrand" + GetRndNr());
            Assert.IsNotNull(testBrand, "Kan inte skapa Brand");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // cleanup the testdata
            Assert.IsTrue(bs.DeleteBrand(testBrand.Id), "Could not delete brand with id " + testBrand.Id);
        }

        private int GetRndNr() {
            var r = new Random();

            return r.Next(0, 99);
        }
    
        [TestMethod]
        [TestCategory("LureTest")]
        public void AddOneLure()
        {

            int brandid = testBrand.Id;
            var weight = 27;
            string color = "Green";
            Lure theLure = ls.AddLure("Luretest" + GetRndNr(), brandid, weight, color);

            Assert.IsNotNull(theLure, "Gick inte att skapa Lure");

            int lureid = theLure.Id;

            // cleanup
            Assert.IsTrue(ls.DeleteLure(lureid), "Could not delete lure with id " + lureid);
        }

        [TestMethod]
        [TestCategory("LureTest")]
        public void ChangeOneLure()
        {
            int brandid = testBrand.Id;
            var weight = 22;
            string color = "Blue";
            Lure theLure = ls.AddLure("Luretest" + GetRndNr(), brandid, weight, color);

            Assert.IsNotNull(theLure, "Kan inte skapa Lure");

            int lureid = theLure.Id;
            ls.UpdateLure(lureid, brandid, "AnotherName", weight+1, color);
            Lure newLure = ls.GetLure(lureid);

            Assert.AreEqual("AnotherName", newLure.Name);
            Assert.AreEqual(weight+1, newLure.Weight);

            // cleanup
            Assert.IsTrue(ls.DeleteLure(lureid), "Could not delete lure with id "+ lureid);
        }
    }
}
