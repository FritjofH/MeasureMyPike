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
        TestsCommon common;

        int ANTAL_TESTDATA = 4;
        int ANTAL_TESTCATCH = 6;

        [TestInitialize]
        public void Initialize()
        {
            ss = new StatisticsService();
            common = new TestsCommon();

            // generate some base data
            for (int d = 0; d < ANTAL_TESTDATA; d++)
            {
                common.GenerateTestData(d);
            }

            for (int c = 0; c < ANTAL_TESTCATCH; c++)
            {
                common.GenerateTestCatch(c, c % ANTAL_TESTDATA);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // cleanup the testdata
            common.CleanupTestCatches();
            common.CleanupTestData();
        }

        private void PrintStat(Statistics stat)
        {
            Console.WriteLine("ID=" + stat.Id);
            Console.WriteLine(" Timestamp = " + stat.Timestamp);
            Console.WriteLine(" CatchId = " + stat.CatchId);
            Console.WriteLine(" UserId = " + stat.UserId);
            Console.WriteLine(" UserName = " + stat.UserName);
            Console.WriteLine(" Comment = " + stat.Comment);
            Console.WriteLine(" FishId = " + stat.FishId);
            Console.WriteLine(" FishLength = " + stat.FishLength);
            Console.WriteLine(" FishWeight = " + stat.FishWeight);
            Console.WriteLine(" LocationId = " + stat.LocationId);
            Console.WriteLine(" LocationCoordinates = " + stat.LocationCoordinates);
            Console.WriteLine(" LakeId = " + stat.LakeId);
            Console.WriteLine(" LakeName = " + stat.LakeName);
            Console.WriteLine(" LureId = " + stat.LureId);
            Console.WriteLine(" LureName = " + stat.LureName);
            Console.WriteLine(" LureBrand = " + stat.LureBrand);
            Console.WriteLine(" LureWeight = " + stat.LureWeight);
            Console.WriteLine(" AirTemperature = " + stat.AirTemperature);
            Console.WriteLine(" WaterTemperature = " + stat.WaterTemperature);
            Console.WriteLine(" Weather = " + stat.Weather);
            Console.WriteLine(" MoonPhase = " + stat.MoonPhase);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetAllStats()
        {
            List<Statistics> statList = ss.GetAllStatistics();
            Assert.IsNotNull(statList, "Kunde inte hämta all statistik");

            // så många totalt fångster
            Assert.AreEqual(ANTAL_TESTCATCH, statList.Count, "Förväntat antal fångster var "+ANTAL_TESTCATCH+". Var inte databasen tom innan enhetstestet?");

            PrintStat(statList[0]);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForUser()
        {
            List<Statistics> statList = ss.CatchesForUser(common.userList[0].Id);
            Assert.IsNotNull(statList, "Kunde inte hämta statistik för user " + common.userList[0].Username);

            // så många fångster av den användaren
            Assert.AreEqual(Math.Ceiling(1.0 * ANTAL_TESTCATCH / ANTAL_TESTDATA), statList.Count);

            if (statList.Count > 0)
                PrintStat(statList[0]);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForLake()
        {
            List<Statistics> statList = ss.CatchesForLake(common.lakeList[1].Id);
            Assert.IsNotNull(statList, "Kunde inte hämta statistik för sjö " + common.lakeList[1].Name);

            // Så många fångster i den sjön
            Assert.AreEqual(Math.Ceiling(1.0 * ANTAL_TESTCATCH / ANTAL_TESTDATA), statList.Count);

            if (statList.Count > 0)
                PrintStat(statList[0]);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetTopLakes()
        {
            List<LakeStatistics> lakeList = ss.LakeTopList(new DateTime().AddSeconds(-5));
            Assert.IsNotNull(lakeList, "Kunde inte hämta topplista för sjöar");

            // Så många sjöar har vi skapat
            Assert.AreEqual(ANTAL_TESTDATA, lakeList.Count, "Vi förväntade oss "+ANTAL_TESTDATA+" sjöar. Var inte databasen tom innan enhetstestet?");

            // så många fångster i första sjön
            Assert.AreEqual(Math.Ceiling(1.0 * ANTAL_TESTCATCH / ANTAL_TESTDATA), lakeList[0].CatchId.Count);

            int[] weightarr = new int[ANTAL_TESTDATA];
            for (int i=0; i < ANTAL_TESTDATA; i++)
            {
                weightarr[i] = 0;
            }

            // De vikter som kommer att beräknas per sjö
            for (int c=0; c < ANTAL_TESTCATCH; c++)
            {
                int lake = c % ANTAL_TESTDATA;
                int w = 750 + 200 * c;
                weightarr[lake] += w;
            }

            // men vi får sorterad lista så det är max-sjön vi letar efter
            int maxw = 0;
            for (int lake=0; lake< weightarr.Length; lake++)
            {
                if (weightarr[lake]>maxw)
                    maxw=weightarr[lake];
            }

            // total vikt i bästa sjön
            Assert.AreEqual(maxw, lakeList[0].TotalFishWeight);

            foreach (LakeStatistics ls in lakeList)
            {
                Console.WriteLine("Sjö             : " + ls.LakeName);
                Console.WriteLine("Total mängd fisk: " + ls.TotalFishWeight + " gram");
                Console.WriteLine("Total längd fisk: " + ls.TotalFishLength + " cm");
                Console.WriteLine("Antal fångster  : " + ls.CatchId.Count);
            }

        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestFishTopList()
        {
            List<Statistics> fishList = ss.FishTopList(new DateTime().Subtract(new TimeSpan(0,0,-10)));
            Assert.IsNotNull(fishList, "Kunde inte hämta topplista för fiskar");

            // Så många fiskar
            Assert.AreEqual(ANTAL_TESTCATCH, fishList.Count, "Vi förväntade oss " + ANTAL_TESTCATCH + " fiskar. Var inte databasen tom innan enhetstestet?");

            // Största fisken
            int maxw = 750 + 200 * (ANTAL_TESTCATCH-1);  // gram
            Assert.AreEqual(maxw, fishList[0].FishWeight);

        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestLatestCatces()
        {
            List<Statistics> fishList = ss.LatestCatches(3);
            Assert.IsNotNull(fishList, "Kunde inte hämta senaste fiskar");

            // Så många fiskar
            Assert.AreEqual(3, fishList.Count);

            // Senaste fisken
            int maxw = 750 + 200 * (ANTAL_TESTCATCH - 1);  // gram
            Assert.AreEqual(maxw, fishList[2].FishWeight);

        }
    }
}
