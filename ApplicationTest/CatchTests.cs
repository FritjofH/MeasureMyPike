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
        DatabaseConnection dbconn;

        [TestInitialize]
        public void Initialize()
        {
            dbconn = new DatabaseConnection();
        }

        [TestMethod]
        [TestCategory("CatchTest")]
        public void createCatch()
        {
            //Fiskbild och konverting till en bytearray
            Image i = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");
            MediaService ms = new MediaService();
            BrandService bs = new BrandService();
            bs.addBrand("theBrand7");
            var result = dbconn.createCatch(ms.ImageToByteArray(i), i.RawFormat.ToString(), "Jag fångade en fisk", "Mask", "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", bs.getBrand(1));

            Assert.IsTrue(result, "Något gick fel vid skapandet av fångsten");
        }
    }
}
