using MeasureMyPike.Models.Application;
using MeasureMyPike.Domain.Models;
using MeasureMyPike.Application.Common;
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
            var conversionService = new ConversionUtil();

            return conversionService.ConvertToUser(createdUser);
        }

        public User GetUser(string username)
        {
            var selectedUser = GetUserDO(username);
            var conversionService = new ConversionUtil();

            return conversionService.ConvertToUser(selectedUser);
        }
        public UserDO GetUserDO(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);

            return selectedUser;
        }

        public UserDO GetUserDO(int id)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(id);

            return selectedUser;
        }

        public bool DeleteUser(string username)
        {
            var userToDelete = GetUserDO(username);
            var userRepo = new UserRepository();
            var deleted = userRepo.DeleteUser(userToDelete);

            return deleted;
        }

        public bool DeleteUser(int id)
        {
            var userToDelete = GetUserDO(id);
            var userRepo = new UserRepository();
            var deleted = userRepo.DeleteUser(userToDelete);

            return deleted;
        }

        public User UpdateUser(string firstName, string lastName, string username)
        {
            var userRepo = new UserRepository();
            var conversionService = new ConversionUtil();

            var updatedUser = userRepo.UpdateUser(firstName, lastName, username);

            return conversionService.ConvertToUser(updatedUser);
        }
    }
}
