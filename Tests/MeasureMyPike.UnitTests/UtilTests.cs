using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Application.Common;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class UtilTests
    {

        [TestInitialize]
        public void Initialize()
        {
            ;
        }

        [TestMethod]
        [TestCategory("UtilTest")]
        public void TestMoonPhases()
        {
            DateTime datum1 = new DateTime(2000, 1, 6);
            int phase = MoonUtil.DateToPhase(datum1);
            Assert.AreEqual(0, phase, "Fel månfas uträknad för datum 2000-01-06");
            
        }

        [TestMethod]
        [TestCategory("UtilTest")]
        public void TestConversion()
        {
            
        }
    }
}
