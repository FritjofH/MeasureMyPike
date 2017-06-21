using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;

namespace ApplicationTest
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
        private int getRndNr() {
            var r = new Random();

            return r.Next(0, 100); //for ints
        }
    
        //[TestMethod]
        //[TestCategory("LureTest")]
        //public void createLure()
        //{
        //    var rnd = getRndNr();
        //    var brand = bs.GetBrand(1);
        //    var result = ls.AddLure("MyLure9" + rnd, brand);

        //    Assert.IsNotNull(result, "Gick inte att skapa");            
        //}

        //[TestMethod]
        //[TestCategory("LureTest")]
        //public void updateLure()
        //{
        //    var rnd = getRndNr();
        //    var brand = bs.GetBrand(1);
            
        //    Assert.IsNotNull(ls.AddLure("MyLureorg1" + rnd, brand), "Gick inte att skapa");
        //    Assert.IsNotNull(ls.UpdateLure(ls.GetLure(1).id, "MyLureupd1" + rnd), "Gick inte att skapa");
        //}
    }
}
