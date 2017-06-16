using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;

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
            var lure1 = "Röd Pilk 50g";

            var createdBrand = bs.AddBrand("Grönlunds Fiske");
            var createdLure = ls.AddLure(lure1, bs.GetBrand(createdBrand.Id));

            var result = cs.CreateCatch(ms.ImageToByteArray(i), ms.getImageFormat(i), "Jag fångade en fisk", ls.GetLure(createdLure.Id), "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen", "hostf");

            Assert.IsNotNull(result, "Något gick fel vid skapandet av fångsten");
        }
    }
}
