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
            UserRepository dbconn = new UserRepository();

            return dbconn.DeleteUser(username);
        }

        public User GetUser(string username)
        {
            UserRepository dbconn = new UserRepository();

            var selectedUser = dbconn.GetUser(username);

            return convertToUser(selectedUser);
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
