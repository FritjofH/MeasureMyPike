using System.Collections.Generic;
using MeasureMyPike.Repo;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;
using System;

namespace MeasureMyPike.Service

{
    public class LakeService : ILakeService
    {
        public Lake AddLake(string name)
        {
            var lakeRepo = new LakeRepository();
            var conversionService = new ConversionService();
            var lake = new LakeDO { Name = name };
            var createdLake = lakeRepo.AddLake(lake);

            return conversionService.ConvertToLake(createdLake);
        }

        public bool DeleteLake(int id)
        {
            var lakeRepo = new LakeRepository();
            var lakeToDelete = GetLakeDO(id);
            System.Console.WriteLine("got lake with id {0} : {1}", id, lakeToDelete);
            var deleted = lakeRepo.DeleteLake(lakeToDelete);

            return deleted;
        }

        public List<Lake> GetAllLakes()
        {
            var lakeRepo = new LakeRepository();
            var conversionService = new ConversionService();
            var lakeList = new List<Lake>();

            foreach (var lake in lakeRepo.GetAllLakes())
            {
                lakeList.Add(conversionService.ConvertToLake(lake));
            }

            return lakeList;
        }

        public Lake GetLake(int id)
        {
            var lake = GetLakeDO(id);
            var conversionService = new ConversionService();

            return conversionService.ConvertToLake(lake);

        }

        public Lake GetLake(string name)
        {
            var lake = GetLakeDO(name);
            var conversionService = new ConversionService();

            return conversionService.ConvertToLake(lake);
        }

        public LakeDO GetLakeDO(int id)
        {
            var lakeRepo = new LakeRepository();
            var conversionService = new ConversionService();
            var lake = lakeRepo.GetLake(id);

            return lake;
        }

        public LakeDO GetLakeDO(string name)
        {
            var lakeRepo = new LakeRepository();
            var conversionService = new ConversionService();
            var lake = lakeRepo.GetLake(name);

            return lake;
        }

        public bool UpdateLake(int id, string name)
        {
            var lakeRepo = new LakeRepository();
            return lakeRepo.UpdateLake(id, name);
        }
    }
}