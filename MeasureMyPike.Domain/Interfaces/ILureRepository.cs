using System.Collections.Generic;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface ILureRepository
    {
        LureDO AddLure(LureDO newLure);
        bool DeleteLure(LureDO lureToDelete);
        List<LureDO> GetAllLures();
        LureDO GetLure(int id);
        bool UpdateLure(int id, string lureName, int weight, string colour);
    }
}