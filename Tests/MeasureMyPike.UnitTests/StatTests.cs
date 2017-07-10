using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.Collections.Generic;
using MeasureMyPike.Models.Application;
using System.Drawing;
using System.IO;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class StatTests
    {
        IStatisticsService ss;

        [TestInitialize]
        public void Initialize()
        {
            ss = new StatisticsService();
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetAllStats()
        {
            // we need some base data
            var common = new TestsCommon();
            common.GenerateTestData();
            common.GenerateTestCatch();

            List<Statistics> statList = ss.GetAllStatistics();
            Assert.IsNotNull(statList, "Kunde inte hämta statistics");

            // cleanup
            common.CleanupTestCatch();
            common.CleanupTestData();
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForUser()
        {
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForLake()
        {
        }

    }
}
