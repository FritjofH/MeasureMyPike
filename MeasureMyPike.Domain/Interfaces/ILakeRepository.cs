using System.Collections.Generic;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface ILakeRepository
    {
        LakeDO AddLake(LakeDO newLake);
        bool DeleteLake(LakeDO lakeToDelete);
        List<LakeDO> GetAllLakes();
        LakeDO GetLake(int id);
        LakeDO GetLake(string name);
        bool UpdateLake(int id, string name);
    }
}