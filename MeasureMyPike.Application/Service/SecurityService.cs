﻿using MeasureMyPike.Application.Common;
using MeasureMyPike.Models.Application;
using MeasureMyPike.Repo;
using System;
using System.Security.Cryptography;

namespace MeasureMyPike.Service
{
    public class SecurityService : ISecurityService
    {
        public string HashAndSaltPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public User Login(string username, string password)
        {
            var userRepo = new UserRepository();
            var userService = new UserService();

            var user = userService.GetUser(username);
            var hashString = userRepo.GetUserPasswordHash(username);
            if (hashString == null)
            {
                Console.WriteLine("Username "+username+" not found or password is empty");
                return null;
            }

            byte[] hashBytes = Convert.FromBase64String(hashString);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    //throw new UnauthorizedAccessException();
                    return null;
                }
            return user;
        }
    }
}
