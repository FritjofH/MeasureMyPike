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

        [TestInitialize]
        public void Initialize()
        {
            ls = new LureService();
            bs = new BrandService();
        }
        private int GetRndNr() {
            var r = new Random();

            return r.Next(0, 99);
        }
    
        [TestMethod]
        [TestCategory("LureTest")]
        public void AddOneLure()
        {
            Brand newBrand = bs.AddBrand("testBrand" + GetRndNr());

            Assert.IsNotNull(newBrand, "Kan inte skapa Brand");

            int brandid = newBrand.Id;
            var weight = 27;
            string color = "Green";
            Lure theLure = ls.AddLure("Luretest" + GetRndNr(), brandid, weight, color);

            Assert.IsNotNull(theLure, "Gick inte att skapa Lure");

            int lureid = theLure.Id;

            // cleanup
            Assert.IsTrue(ls.DeleteLure(lureid), "Could not delete lure with id " + lureid);
            Assert.IsTrue(bs.DeleteBrand(brandid), "Could not delete brand with id " + brandid);
        }

        [TestMethod]
        [TestCategory("LureTest")]
        public void ChangeOneLure()
        {
            Brand newBrand = bs.AddBrand("testBrand" + GetRndNr());

            Assert.IsNotNull(newBrand, "Kan inte skapa Brand");

            int brandid = newBrand.Id;
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
            Assert.IsTrue(bs.DeleteBrand(brandid), "Could not delete brand with id " + brandid);
        }
    }
}
