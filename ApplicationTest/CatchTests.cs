using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Application;
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
        public void createCatch()
        {
            //Fiskbild och konverting till en bytearray
            Image i = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");

            var result = cs.createCatch(ms.ImageToByteArray(i), ms.getImageFormat(i), "Jag fångade en fisk", ls.getFirstLure(), "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", bs.GetBrand(1), "hostf");

            Assert.IsTrue(result, "Något gick fel vid skapandet av fångsten");
        }
    }
}
