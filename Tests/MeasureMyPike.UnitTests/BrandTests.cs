using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class BrandTests
    {
        BrandService bs;

        [TestInitialize]
        public void Initialize()
        {
            bs = new BrandService();
        }

        [TestMethod]
        public void GetOneBrand()
        {
            var rnd = new Random();
            var result = bs.AddBrand("Abu garcia" + rnd.Next(1, 99));
            Assert.IsNotNull(result);
        }
    }
}
