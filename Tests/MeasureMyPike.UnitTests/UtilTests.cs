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
            Assert.AreEqual((int)MoonUtil.Phases.NEW_MOON, phase, "Fel månfas uträknad för datum 2000-01-06");

            // test
            /*
            DateTime dd = new DateTime(2000, 1, 6);
            int i = 0;
            while (i<45)
            {
                i++;
                dd = dd.AddDays(1);
                Console.WriteLine("Datum "+dd+"  Fas "+MoonUtil.DateToPhase(dd)+" "+MoonUtil.Phase(dd));
            }
            */

            DateTime datum2 = new DateTime(2017, 7, 9);
            string fas = MoonUtil.Phase(datum2);
            Assert.AreEqual("Fullmåne", fas, "Fel månfas uträknad för datum 2017-07-09");
        }

        [TestMethod]
        [TestCategory("UtilTest")]
        public void TestConversion()
        {
            
        }
    }
}
