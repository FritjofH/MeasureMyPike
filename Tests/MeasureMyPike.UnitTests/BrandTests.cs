using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.Collections.Generic;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class BrandTests
    {
        IBrandService bs;

        [TestInitialize]
        public void Initialize()
        {
            bs = new BrandService();
        }

        [TestMethod]
        [TestCategory("BrandTest")]
        public void CreateOneBrand()
        {
            var rnd = new Random();
            var result = bs.AddBrand("Abu test" + rnd.Next(1, 99));

            Assert.IsNotNull(result);

            // cleanup
            Assert.IsTrue(bs.DeleteBrand(result.Id), "Could not delete brand with id "+result.Id);
        }

        [TestMethod]
        [TestCategory("BrandTest")]
        public void ChangeOneBrand()
        {
            var rnd = new Random();
            Brand theBrand = bs.AddBrand("Abu test" + rnd.Next(1, 99));
            bs.UpdateBrand(theBrand.Id, "Abu newname");
            Brand b2 = bs.GetBrand(theBrand.Id);

            Assert.AreEqual("Abu newname", b2.Name);

            // cleanup
            Assert.IsTrue(bs.DeleteBrand(b2.Id), "Could not delete brand with id " + b2.Id);
        }
    }
}
