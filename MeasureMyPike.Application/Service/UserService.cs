using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System;

namespace MeasureMyPike.Service
{
    public class UserService : IUserService
    {
        public User CreateUser(string lastName, string firstName, string username, string password)
        {
            var userRepo = new UserRepository();
            var securityService = new SecurityService();
            var hashedPassword = securityService.HashAndSaltPassword(password);
            var user = new UserDO
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                MemberSince = DateTime.Now,
                Security = new SecurityDO { Password = hashedPassword }
            };
            var createdUser = userRepo.AddUser(user);
            var conversionService = new ConversionService();

            return conversionService.convertToUser(createdUser);
        }

        public User GetUser(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);
            var conversionService = new ConversionService();

            return conversionService.convertToUser(selectedUser);
        }
        public UserDO GetUserDO(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);

            return selectedUser;
        }

        public bool DeleteUser(string username)
        {
            var userRepo = new UserRepository();
            var userToDelete = GetUserDO(username);
            var deleted = userRepo.DeleteUser(userToDelete);

            return deleted;
        }
    }
}
