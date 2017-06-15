using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public class LureService : ILureService
    {
        public Lure AddLure(string lureName, Brand brand)
        {
            var lureRepo = new LureRepository();
            var brandService = new BrandService();
            var conversionService = new ConversionService();
            var lure = new LureDO
            {
                Name = lureName,
                Brand = brandService.GetBrandDO(brand.Id),
                Catch = null
            };
            var createdLure = lureRepo.AddLure(lure);

            return conversionService.convertToLure(createdLure);
        }

        public Lure GetLure(int id)
        {
            var lureRepo = new LureRepository();
            var conversionService = new ConversionService();
            var selectedLure = lureRepo.GetLure(id);

            return conversionService.convertToLure(selectedLure);
        }

        public LureDO GetLureDO(int id)
        {
            var lureRepo = new LureRepository();
            var selectedLure = lureRepo.GetLure(id);

            return selectedLure;
        }

        public bool DeleteLure(int id)
        {
            var lureRepo = new LureRepository();
            var lureToDelete = GetLureDO(id);
            var deleted = lureRepo.DeleteLure(lureToDelete);

            return deleted;
        }

        public Lure UpdateLure(int id, string name)
        {
            var lureRepo = new LureRepository();
            var conversionService = new ConversionService();
            var updatedLure = lureRepo.UpdateLure(id, name);

            return conversionService.convertToLure(updatedLure);
        }

    }
}
