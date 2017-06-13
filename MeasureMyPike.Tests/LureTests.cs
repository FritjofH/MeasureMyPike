using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike;
using System.IO;
using System.Drawing;
using MeasureMyPike.Service;
using MeasureMyPike.Models.Entity_Framework;

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
            var brand = bs.getBrand(1);
            var result = ls.addLure("MyLure9" + rnd, brand);
            Assert.IsTrue(result, "Gick inte att skapa");            
        }

        [TestMethod]
        [TestCategory("LureTest")]
        public void updateLure()
        {
            int rnd = getRndNr();
            
            Brand brand = bs.getBrand(1);
            
            Assert.IsTrue(ls.addLure("MyLureorg1" + rnd, brand), "Gick inte att skapa");
            
            Assert.IsTrue(ls.updateLure(ls.getLure(1).Id, "MyLureupd1" + rnd), "Gick inte att skapa");


        }
    }
}
