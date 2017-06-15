using System.Collections.Generic;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public interface ILureRepository
    {
        LureDO AddLure(LureDO newLure);
        bool DeleteLure(LureDO lureToDelete);
        List<LureDO> GetAllLures();
        LureDO GetLure(int id);
        LureDO UpdateLure(int id, string lureName);
    }
}