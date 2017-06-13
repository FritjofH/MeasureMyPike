using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using MeasureMyPike.Models.Entity_Framework;

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
        public void TestMethod1()
        {
            Random rnd = new Random();
            var newBrand = new Brand { Name = "Abu garcia" + rnd.Next(1,99)};

            bs.AddBrand(newBrand);
        }
    }
}
