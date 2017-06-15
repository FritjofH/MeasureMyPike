using MeasureMyPike.Models.Application;
using MeasureMyPike.Models.Entity_Framework;
using MeasureMyPike.Repo;
using System;

namespace MeasureMyPike.Service
{
    public class UserService
    {
        public User CreateUser(string lastName, string firstName, string username, string password)
        {
            var userRepo = new UserRepository();
            var ss = new SecurityService();
            var hashedPassword = ss.HashAndSaltPassword(password);
            var user = new UserDO
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                MemberSince = DateTime.Now,
                Security = new SecurityDO { Password = hashedPassword }
            };
            var createdUser = userRepo.AddUser(user);

            return convertToUser(createdUser);
        }

        public bool DeleteUser(string username)
        {
            var userRepo = new UserRepository();
            var userToDelete = GetUserDO(username);
            var deleted = userRepo.DeleteUser(userToDelete);

            return deleted;
        }

        public User GetUser(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);

            return convertToUser(selectedUser);
        }
        public UserDO GetUserDO(string username)
        {
            var userRepo = new UserRepository();
            var selectedUser = userRepo.GetUser(username);

            return selectedUser;
        }

        private User convertToUser(UserDO userToConvert)
        {
            return new User {
                FirstName = userToConvert.FirstName,
                LastName = userToConvert.LastName,
                MemberSince = userToConvert.MemberSince,
                Id = userToConvert.Id,
                Username = userToConvert.Username
            };
        }
    }
}
