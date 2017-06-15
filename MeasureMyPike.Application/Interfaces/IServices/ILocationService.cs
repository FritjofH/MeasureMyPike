using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Service
{
    public interface ILocationService
    {
        Location AddLocation(string lake, string coordinates);
        bool DeleteLocation(int id);
        Location GetLocation(int id);
        LocationDO GetLocationDO(int id);
        Location UpdateLocation(int id, string name, string coordinates);
    }
}