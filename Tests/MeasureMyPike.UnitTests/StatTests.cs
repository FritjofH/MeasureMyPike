﻿using System;
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

        [TestInitialize]
        public void Initialize()
        {
            ss = new StatisticsService();
            common = new TestsCommon();

            // generate some base data
            common.GenerateTestData();
            common.GenerateTestCatch();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // cleanup the testdata
            common.CleanupTestCatch();
            common.CleanupTestData();
        }

        private void PrintStat(Statistics stat)
        {
            Console.WriteLine("ID=" + stat.Id);
            Console.WriteLine(" Timestamp = " + stat.Timestamp);
            Console.WriteLine(" CatchId = " + stat.CatchId);
            Console.WriteLine(" UserId = " + stat.UserId );
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

            Console.WriteLine("antal " + statList.Count);
            if (statList.Count > 0)
                PrintStat(statList[0]);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForUser()
        {
            List<Statistics> statList = ss.GetStatisticsForUser(common.theUser);
            Assert.IsNotNull(statList, "Kunde inte hämta statistik för user "+common.theUser.Username);

            Console.WriteLine("antal " + statList.Count);
            if (statList.Count > 0)
                PrintStat(statList[0]);
        }

        [TestMethod]
        [TestCategory("StatTest")]
        public void TestGetStatsForLake()
        {
            List<Statistics> statList = ss.GetStatisticsForLake(common.theLake);
            Assert.IsNotNull(statList, "Kunde inte hämta statistik för sjö " + common.theLake.Name);

            Console.WriteLine("antal " + statList.Count);
            if (statList.Count > 0)
                PrintStat(statList[0]);
        }

    }
}
