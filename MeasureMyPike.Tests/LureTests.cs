using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike;
using System.IO;
using System.Drawing;
using MeasureMyPike.Service;

namespace ApplicationTest
{
    using mmp = MeasureMyPike;
    [TestClass]
    public class LureTests
    {        
        LureService ls;
        BrandService bs;

        [TestInitialize]
        public void Initialize()
        {
            //dbconn = new DatabaseConnection();
            ls = new LureService();
            bs = new BrandService();
        }
        private int getRndNr() {
            Random r = new Random();
            return r.Next(0, 100); //for ints
        }
    
        [TestMethod]
        [TestCategory("LureTest")]
        public void createLure()
        {
            int rnd = getRndNr();
            bs.AddBrand("theBrand" + rnd);
            mmp.Models.Brand b = bs.getBrand("theBrand" + rnd);
            //ls.addLure("MyLure9" + rnd, b);
            Assert.IsTrue(ls.addLure("MyLure9" + rnd, b), "Gick inte att skapa");
            
        }

        [TestMethod]
        [TestCategory("LureTest")]
        public void updateLure()
        {
            int rnd = getRndNr();
            bs.AddBrand("theBrand1" + rnd);
            mmp.Models.Brand b = bs.getBrand("theBrand1" + rnd);
            
            Assert.IsTrue(ls.addLure("MyLureorg1" + rnd, b), "Gick inte att skapa");
            
            Assert.IsTrue(ls.updateLure(ls.getLure("MyLureorg1" + rnd).Id, "MyLureupd1" + rnd), "Gick inte att skapa");


        }
    }
}
