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
        public List<Lure> lureList = new List<Lure>();
        public List<Brand> brandList = new List<Brand>();
        public List<User> userList = new List<User>();
        public List<Lake> lakeList = new List<Lake>();
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

        public Catch GenerateTestCatch(int num, int datanum)
        {
            if (datanum < lakeList.Count)
            {
                theLake = lakeList[datanum];
            }

            if (datanum < userList.Count)
            {
                theUser = userList[datanum];
            }

            if (datanum < lureList.Count)
            {
                theLure = lureList[datanum];
            }

            theCatch = catchService.AddCatch(
                mediaService.ImageToByteArray(theImage), 
                mediaService.GetImageFormat(theImage), 
                DateTime.Now,  // caught date & time
                "Min enorma gädda", // comment
                theLure, 
                750 + 200*num,  // gram
                34 + 10*num,  // cm
                theLake.Name, 
                "63.179195,14.627282", // x,y koordinater
                15.1 + num,  // water temp
                19.0 + num,  // air temp
                "Soligt",  // weather
                theUser.Username);

            catchList.Add(theCatch);

            return theCatch;
        }

        public bool CleanupTestCatches()
        {
            bool ok = true;
            foreach (Catch c in catchList)
            {
                ok = ok && catchService.DeleteCatch(c.Id);
            }

            catchList.Clear();

            return ok;
        }

        public void GenerateTestData(int num)
        {
            var rnd = new Random();

            int lureWeight = 18 + num*2;
            string lureColor = "Red";
            string lureName = "testLure" + rnd.Next(0, 999) + num;
            string brandName = "testBrand" + rnd.Next(0, 999) + num;
            string fnamn = "Förnamn" + rnd.Next(0, 999) + num;
            string enamn = "Efternamn" + rnd.Next(0, 999) + num;
            string userName = "testUser" + rnd.Next(0, 999) + num;
            string pass = "hemligt";
            string lakeName = "testSjö" + rnd.Next(0, 999) + num;

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

            userList.Add(theUser);
            brandList.Add(theBrand);
            lureList.Add(theLure);
            lakeList.Add(theLake);
        }

        public bool CleanupTestData()
        {
            // cleanup of predefined data
            return DeleteLures()
                && DeleteBrands()
                && DeleteUsers()
                && DeleteLakes();
        }

        private bool DeleteLures()
        {
            bool ok = true;
            foreach (Lure l in lureList)
            {
                ok = ok && lureService.DeleteLure(l.Id);
            }

            lureList.Clear();

            return ok;
        }

        private bool DeleteBrands()
        {
            bool ok = true;
            foreach (Brand b in brandList)
            {
                ok = ok && brandService.DeleteBrand(b.Id);
            }

            brandList.Clear();

            return ok;
        }

        private bool DeleteUsers()
        {
            bool ok = true;
            foreach (User u in userList)
            {
                ok = ok && userService.DeleteUser(u.Id);
            }

            userList.Clear();

            return ok;
        }

        private bool DeleteLakes()
        {
            bool ok = true;
            foreach (Lake l in lakeList)
            {
                ok = ok && lakeService.DeleteLake(l.Id);
            }

            lakeList.Clear();

            return ok;
        }
    }
}
