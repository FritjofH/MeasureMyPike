using MeasureMyPike.Domain.Models;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;
using System.Collections.Generic;
using System;

namespace MeasureMyPike.Service
{
    public class LureService : ILureService
    {
        public Lure AddLure(string lureName, int brandId, int? weight, string colour)
        {
            var lureRepo = new LureRepository();
            var brandService = new BrandService();
            var conversionService = new ConversionService();
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
            var lureRepo = new LureRepository();
            var conversionService = new ConversionService();
            var selectedLure = lureRepo.GetLure(id);

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
            var conversionService = new ConversionService();
            var lureList = new List<Lure>();

            foreach (var lure in lureRepo.GetAllLures())
            {
                lureList.Add(conversionService.ConvertToLure(lure));
            }

            return lureList;
        }

        public Lure UpdateLure(int id, int brand, string name, int? weight, string colour)
        {
            var lureRepo = new LureRepository();
            var conversionService = new ConversionService();
            var updatedLure = lureRepo.UpdateLure(id, name);

            return conversionService.ConvertToLure(updatedLure);
        }

        public bool DeleteLure(int id)
        {
            var lureRepo = new LureRepository();
            var lureToDelete = GetLureDO(id);
            var deleted = lureRepo.DeleteLure(lureToDelete);

            return deleted;
        }

        public List<Lure> getAllLures()
        {
            var lureRepo = new LureRepository();
            var conversionService = new ConversionService();
            var lureList = new List<Lure>();

            foreach (var lure in lureRepo.GetAllLures())
            {
                lureList.Add(conversionService.ConvertToLure(lure));
            }

            return lureList;
        }
    }
}
