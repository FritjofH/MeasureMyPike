using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public class FishService
    {
        //public Fish AddFish(string length, string weight)
        //{
        //    var fishRepo = new FishRepository();

        //    var fish = new FishDO
        //    {
        //        Length = length,
        //        Weight = weight
        //    };

        //    var createdFish = fishRepo.AddFish(fish);

        //    return convertToFish(createdFish);
        //}


        public Fish GetFish(int id)
        {
            var fishRepo = new FishRepository();
            var selectedFish = fishRepo.GetFish(id);

            return convertToFish(selectedFish);
        }

        public FishDO GetFishDO(int id)
        {
            var fishRepo = new FishRepository();
            var selectedFish = fishRepo.GetFish(id);

            return selectedFish;
        }

        public bool DeleteFish(int id)
        {
            var fishRepo = new FishRepository();
            var fishToDelete = GetFishDO(id);
            var deleted = fishRepo.DeleteFish(fishToDelete);
            return deleted;
        }

        public Fish UpdateFish(int id, string length, string weight)
        {
            var fishRepo = new FishRepository();
            var updatedFish = fishRepo.UpdateFish(id, length, weight);

            return convertToFish(updatedFish);
        }

        private Fish convertToFish(FishDO fishToConvert)
        {
            return new Fish { Id = fishToConvert.Id, Length = fishToConvert.Length, Weight = fishToConvert.Weight };
        }

    }
}
