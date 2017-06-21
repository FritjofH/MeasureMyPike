using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Service
{
    public interface ILureService
    {
        Lure AddLure(string lureName, int brandId, int? weight, string colour);
        bool DeleteLure(int id);
        Lure GetLure(int id);
        LureDO GetLureDO(int id);
        Lure UpdateLure(int id, int brandId, string name, int? weight, string colour);
    }
}