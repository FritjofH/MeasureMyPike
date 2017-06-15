using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;

namespace MeasureMyPike.Service
{
    public interface IUserService
    {
        User CreateUser(string lastName, string firstName, string username, string password);
        bool DeleteUser(string username);
        User GetUser(string username);
        UserDO GetUserDO(string username);
    }
}