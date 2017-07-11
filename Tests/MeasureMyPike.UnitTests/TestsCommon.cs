using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeasureMyPike.Service;
using System.IO;
using System.Drawing;
using System;
using MeasureMyPike.Models.Application;
using System.Collections.Generic;

namespace MeasureMyPike.Tests
{
    public class TestsCommon
    {
        public ICatchService catchService;
        public IMediaService mediaService;
        public IBrandService brandService;
        public ILureService lureService;
        public IUserService userService;
        public ILakeService lakeService;

        public Lure theLure;
        public Brand theBrand;
        public User theUser;
        public Lake theLake;
        public Catch theCatch;
        public Image theImage;
        public List<Catch> catchList = new List<Catch>();

        public TestsCommon()
        {
            catchService = new CatchService();
            mediaService = new MediaService();
            brandService = new BrandService();
            lureService = new LureService();
            userService = new UserService();
            lakeService = new LakeService();
        }

        public Catch GenerateTestCatch(int scale)
        {
            theCatch = catchService.AddCatch(
                mediaService.ImageToByteArray(theImage), 
                mediaService.GetImageFormat(theImage), 
                DateTime.Now,  // caught date & time
                "Min enorma gädda", // comment
                theLure, 
                750 + 200*scale,  // gram
                34 + 10*scale,  // cm
                theLake.Name, 
                "63.179195,14.627282", // x,y koordinater
                15.1 + scale,  // water temp
                19.0 + scale,  // air temp
                "Soligt",  // weather
                theUser.Username);

            catchList.Add(theCatch);

            return theCatch;
        }

        public Catch GenerateTestCatch()
        {
            return GenerateTestCatch(0);
        }

        public bool CleanupTestCatch()
        {
            bool ok = true;
            foreach (Catch c in catchList)
            {
                ok = ok && catchService.DeleteCatch(c.Id);
            }

            catchList.Clear();

            return ok;
        }

        public void GenerateTestData()
        {
            var rnd = new Random();

            int lureWeight = 24;
            string lureColor = "Red";
            string lureName = "testLure" + rnd.Next(0, 999);
            string brandName = "testBrand" + rnd.Next(0, 999);
            string fnamn = "Förnamn" + rnd.Next(0, 999);
            string enamn = "Efternamn" + rnd.Next(0, 999);
            string userName = "testUser" + rnd.Next(0, 999);
            string pass = "hemligt";
            string lakeName = "testSjö" + rnd.Next(0, 999);
            //Fiskbild och konverting till en bytearray
            theImage = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Mockdata\\Fisk.jpg");

            // Setup of needed predefined data
            theUser = userService.CreateUser(enamn, fnamn, userName, pass);
            Assert.IsNotNull(theUser, "Kunde inte skapa testUser " + userName);
            theBrand = brandService.AddBrand(brandName);
            Assert.IsNotNull(theBrand, "Kunde inte skapa testBrand " + brandName);
            theLure = lureService.AddLure(lureName, theBrand.Id, lureWeight, lureColor);
            Assert.IsNotNull(theLure, "Kunde inte skapa testLure " + lureName);
            theLake = lakeService.AddLake(lakeName);
            Assert.IsNotNull(theLake, "Kunde inte skapa testLake " + lakeName);
        }

        public bool CleanupTestData()
        {
            // cleanup of predefined data
            return lureService.DeleteLure(theLure.Id)
                && brandService.DeleteBrand(theBrand.Id)
                && userService.DeleteUser(theUser.Id)
                && lakeService.DeleteLake(theLake.Id);
        }

    }
}
