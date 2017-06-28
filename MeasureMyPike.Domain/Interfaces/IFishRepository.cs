using MeasureMyPike.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Domain.Interfaces.IRepositories
{
    public interface IFishRepository
    {
        FishDO GetFish(int id);
        List<FishDO> GetAllFishes();
        bool UpdateFish(int id, string length, string weight);
        bool DeleteFish(int id);
    }
}
