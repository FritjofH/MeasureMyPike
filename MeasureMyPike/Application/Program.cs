using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using MeasureMyPike.Application;

namespace MeasureMyPike
{
    public class Program
    {
        public static void Main(string[] args)
        {

              //testJohnnysStuff();
            testFhostStuff();
             

             }
        static public void testFhostStuff() {
            DatabaseConnection dbconn = new DatabaseConnection();
            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var resultText = dbconn.createUser("Höst", "Fritjof", "hostf", "hemligt");
            Debug.WriteLine(resultText);

            //Ska fungera
            resultText = dbconn.login("hostf", "hemligt");
            Debug.WriteLine(resultText);

            ////Ska faila
            //resultText = dbconn.login("hostf", "gemligt");
            //Debug.WriteLine(resultText);

            //Fiskbild och konverting till en bytearray
            Image i = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");
            ImageHandler ih = new ImageHandler();
            BrandService bs = new BrandService();
            //bs.addBrand("theBrand7");
            resultText = dbconn.createCatch(ih.ImageToByteArray(i), i.RawFormat.ToString(), "Jag fångade en fisk", "Mask", "75 kilo", "300cm (mellan ögonen)", "Storsjön", "xy", 22, "Soligt", "I himmlen");
        }

        static public void testJohnnysStuff()
        {
            BrandService bs = new BrandService();
            bs.addBrand("theBrand8");
            Model.Brand b = bs.getBrand(1);

            LureService ls = new LureService();
            ls.addLure("MyLure8", b);

        }
    }
}
