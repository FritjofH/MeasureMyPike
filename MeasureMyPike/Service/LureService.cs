using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public class LureService
    {
        public Lure AddLure(string lureName, Brand brand)
        {
            var lureRepo = new LureRepository();
            var bs = new BrandService();

            var lure = new LureDO
            {
                Name = lureName,
                Brand = bs.GetBrandDO(brand.Id),
                Catch = null
            };

            var createdLure = lureRepo.AddLure(lure);

            return convertToLure(createdLure);
        }

        public Lure GetLure(int id)
        {
            var lureRepo = new LureRepository();
            var selectedLure = lureRepo.GetLure(id);

            return convertToLure(selectedLure);
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
            var deleted = lureRepo.DeleteLure(id);

            return deleted;
        }

        public Lure UpdateLure(int id, string name)
        {
            var lureRepo = new LureRepository();
            var updatedLure = lureRepo.UpdateLure(id, name);

            return convertToLure(updatedLure);
        }
        
        private Lure convertToLure(LureDO lureToConvert)
        {
            return new Lure { Id = lureToConvert.Id, Name = lureToConvert.Name };
        }

    }
}
