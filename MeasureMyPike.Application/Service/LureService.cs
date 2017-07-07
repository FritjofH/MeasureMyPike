using MeasureMyPike.Application.Common;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;
using System.Collections.Generic;
using System;

namespace MeasureMyPike.Service
{
    public class LureService : ILureService
    {
        public Lure AddLure(string lureName, int brandId, int weight, string colour)
        {
            var lureRepo = new LureRepository();
            var brandService = new BrandService();
            var conversionService = new ConversionUtil();
            var lure = new LureDO
            {
                Name = lureName,
                Brand = brandService.GetBrandDO(brandId),
                Colour = colour,
                Weight = weight
            };
            var createdLure = lureRepo.AddLure(lure);

            return conversionService.ConvertToLure(createdLure);
        }

        public Lure GetLure(int id)
        {
            var conversionService = new ConversionUtil();
            var selectedLure = GetLureDO(id);

            return conversionService.ConvertToLure(selectedLure);
        }

        public LureDO GetLureDO(int id)
        {
            var lureRepo = new LureRepository();
            var selectedLure = lureRepo.GetLure(id);

            return selectedLure;
        }

        public List<Lure> GetAllLures()
        {
            var lureRepo = new LureRepository();
            var conversionService = new ConversionUtil();
            var lureList = new List<Lure>();

            foreach (var lure in lureRepo.GetAllLures())
            {
                lureList.Add(conversionService.ConvertToLure(lure));
            }

            return lureList;
        }

        public bool UpdateLure(int id, int brand, string name, int weight, string colour)
        {
            var lureRepo = new LureRepository();
            return lureRepo.UpdateLure(id, name, weight, colour);
        }

        public bool DeleteLure(int id)
        {
            var lureRepo = new LureRepository();
            var lureToDelete = GetLureDO(id);
            System.Console.WriteLine("got lure with id {0} : {1}", id, lureToDelete);
            var deleted = lureRepo.DeleteLure(lureToDelete);
            
            return deleted;
        }

    }
}
