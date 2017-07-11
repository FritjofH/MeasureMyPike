using MeasureMyPike.Domain.Models;
using MeasureMyPike.Models.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike.Application.Interfaces
{
    public interface IFishService
    {
        Fish GetFish(int id);

        FishDO GetFishDO(int id);

        bool DeleteFish(int id);

        bool UpdateFish(int id, int length, int weight);
    }
}
