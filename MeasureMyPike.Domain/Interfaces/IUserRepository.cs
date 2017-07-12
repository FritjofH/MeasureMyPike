using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface IUserRepository
    {
        UserDO AddUser(UserDO newUser);
        bool DeleteUser(UserDO userToDelete);
        UserDO GetUser(string username);
        UserDO GetUser(int id);
        string GetUserPasswordHash(string username);
        UserDO UpdateUser(string firstName, string lastName, string username);
    }
}