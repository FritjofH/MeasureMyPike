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

        public TestsCommon()
        {
            catchService = new CatchService();
            mediaService = new MediaService();
            brandService = new BrandService();
            lureService = new LureService();
            userService = new UserService();
            lakeService = new LakeService();
        }

        public Catch GenerateTestCatch()
        {
            theCatch = catchService.AddCatch(mediaService.ImageToByteArray(theImage), mediaService.GetImageFormat(theImage), DateTime.Now, "Min enorma gädda", theLure, "75 kg", "300cm (mellan ögonen)", theLake.Name, "xy", 17.1, 22.0, "Soligt", theUser.Username);
            return theCatch;
        }

        public bool CleanupTestCatch()
        {
            return catchService.DeleteCatch(theCatch.Id);
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
