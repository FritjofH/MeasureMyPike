using System.Collections.Generic;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface ILocationRepository
    {
        LocationDO AddLocation(LocationDO newLocation);
        bool DeleteLocation(LocationDO locationToDelete);
        List<LocationDO> GetAllLocations();
        LocationDO GetLocation(int id);
        bool UpdateLocation(int id, string lake, string coordinates);
    }
}