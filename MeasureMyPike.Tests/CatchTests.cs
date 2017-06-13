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
            bs.AddBrand("Grönlunds Fiske");
            ls.addLure("Röd Pilk 50g", bs.getBrand("Grönlunds Fiske"));

            var result = cs.createCatch(ms.ImageToByteArray(i), ms.getImageFormat(i), "Jag fångade en fisk", ls.getLure(0), "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", bs.getBrand(0), "hostf");

            Assert.IsTrue(result, "Något gick fel vid skapandet av fångsten");
        }
    }
}
