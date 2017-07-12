using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Service
{
    public interface IUserService
    {
        User CreateUser(string lastName, string firstName, string username, string password);
        bool DeleteUser(string username);
        bool DeleteUser(int id);
        User GetUser(string username);
        UserDO GetUserDO(string username);
        User UpdateUser(string firstName, string lastName, string username);
    }
}