using MeasureMyPike.Models.Application;

namespace MeasureMyPike.Service
{
    public interface ISecurityService
    {
        string HashAndSaltPassword(string password);
        User Login(string username, string password);
    }
}