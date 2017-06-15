using MeasureMyPike.Domain.Models;

namespace MeasureMyPike.Repo
{
    public interface IUserRepository
    {
        UserDO AddUser(UserDO newUser);
        bool DeleteUser(UserDO userToDelete);
        UserDO GetUser(string username);
        string GetUserPasswordHash(string username);
    }
}