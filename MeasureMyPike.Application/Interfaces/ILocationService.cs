using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Service
{
    public interface ILocationService
    {
        bool DeleteLocation(int id);
        Location GetLocation(int id);
        LocationDO GetLocationDO(int id);
        bool UpdateLocation(int id, string coordinates);
    }
}