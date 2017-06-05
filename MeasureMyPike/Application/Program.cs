using System.Diagnostics;
using System.Drawing;
using System.IO;
using MeasureMyPike.Application;

namespace MeasureMyPike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            testJohnnysStuff();
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
