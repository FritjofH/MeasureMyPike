using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike.Service
{
    public interface ILakeService
    {
        Lake AddLake(string name);
        bool DeleteLake(int id);
        List<Lake> GetAllLakes();
        Lake GetLake(int id);
        Lake GetLake(string name);
        LakeDO GetLakeDO(int id);
        LakeDO GetLakeDO(string name);
        bool UpdateLake(int id, string name);
    }
}