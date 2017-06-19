using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

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