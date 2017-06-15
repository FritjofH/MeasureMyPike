using System.Collections.Generic;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Repo
{
    public interface ILocationRepository
    {
        LocationDO AddLocation(LocationDO newLocation);
        bool DeleteLocation(LocationDO locationToDelete);
        List<LocationDO> GetAllLocations();
        LocationDO GetLocation(int id);
        LocationDO UpdateLocation(int id, string lake, string coordinates);
    }
}