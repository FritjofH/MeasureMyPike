using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;

namespace MeasureMyPike.Tests
{
    [TestClass]
    public class FishTests
    {

        [TestMethod]
        [TestCategory("FishTests")]
        public void AddFishie()
        {
            var fs = new FishService();
            var length = "30,5";
            var weight = "1,5";

            // fs.AddFish(length, weight);
        }

    }
}
