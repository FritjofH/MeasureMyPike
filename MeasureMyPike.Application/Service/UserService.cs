using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
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
                Security = new SecurityDO { Password = hashedPassword },
                TackleBox = new TackleBoxDO { } // create empty tacklebox for the user
            };
            var createdUser = userRepo.AddUser(user);
            var conversionService = new ConversionService();

            return conversionService.ConvertToUser(createdUser);
        }

        public User GetUser(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);
            var conversionService = new ConversionService();

            return conversionService.ConvertToUser(selectedUser);
        }
        public UserDO GetUserDO(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);

            return selectedUser;
        }

        public bool DeleteUser(string username)
        {
            var userToDelete = GetUserDO(username);
            var userRepo = new UserRepository();
            var deleted = userRepo.DeleteUser(userToDelete);

            return deleted;
        }
    }
}
