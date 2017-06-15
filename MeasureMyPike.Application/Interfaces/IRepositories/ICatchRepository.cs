using System.Collections.Generic;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike
{
    public interface ICatchRepository
    {
        CatchDO AddCatch(CatchDO newCatch);
        bool DeleteCatch(CatchDO catchToDelete);
        List<CatchDO> GetAllCatch();
        CatchDO GetCatch(int id);
        bool UpdateCatch(int id, CatchDO changedCatch);
    }
}