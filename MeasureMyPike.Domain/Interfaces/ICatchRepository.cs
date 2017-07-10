using MeasureMyPike.Domain.Models;
using System.Collections.Generic;

namespace MeasureMyPike
{
    public interface ICatchRepository
    {
        CatchDO AddCatch(CatchDO newCatch);
        bool DeleteCatch(CatchDO catchToDelete);
        List<CatchDO> GetAllCatches();
        List<CatchDO> GetCatches(UserDO aUser);
        CatchDO GetCatch(int id);
        bool UpdateCatch(int id, CatchDO changedCatch);
    }
}