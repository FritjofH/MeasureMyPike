using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using MeasureMyPike;

namespace ApplicationTest
{
    [TestClass]
    public class CatchTests
    {
        CatchService cs;
        MediaService ms;
        BrandService bs;
        LureService ls;

        [TestInitialize]
        public void Initialize()
        {
            cs = new CatchService();
            ms = new MediaService();
            bs = new BrandService();
            ls = new LureService();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void CreateCatch()
        {
            //Fiskbild och konverting till en bytearray
            Image i = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");
            string lure1 = "Röd Pilk 50g";
            string brand1 = "Grönlunds Fiske";

            bs.AddBrand(brand1);
            ls.AddLure(lure1, bs.GetBrand(brand1));

            var result = cs.createCatch(ms.ImageToByteArray(i), ms.getImageFormat(i), "Jag fångade en fisk", ls.GetLure(lure1), "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", bs.GetBrand(brand1), "hostf");

            Assert.IsTrue(result, "Något gick fel vid skapandet av fångsten");
        }
    }
}
