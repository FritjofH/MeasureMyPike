using MeasureMyPike.Models.Application;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MeasureMyPike.Controllers
{
    public class TokenManager
    {
        private static Lazy<byte[]> KEY = new Lazy<byte[]>(() =>
        {
            var key = ConfigurationManager.AppSettings["JwtSecret"];
            return CreateSymmetricKey(key);
        });

        private static Lazy<int> TOKEN_LIFETIME = new Lazy<int>(() =>
        {
            return int.Parse(ConfigurationManager.AppSettings["JwtLifetimeInSeconds"]);
        });

        private static Lazy<string> TOKEN_ISSUER = new Lazy<string>(() => ConfigurationManager.AppSettings["JwtIssuer"]);
        private static Lazy<string> TOKEN_AUDIENCE = new Lazy<string>(() => ConfigurationManager.AppSettings["JwtAudience"]);

        public static string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingCredentials = new SigningCredentials(
                        new InMemorySymmetricSecurityKey(KEY.Value),
                        "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                        "http://www.w3.org/2001/04/xmlenc#sha256");

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new System.Security.Claims.Claim[] {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.GivenName, user.Firstname)
                }),
                TokenIssuerName = TOKEN_ISSUER.Value,
                AppliesToAddress = TOKEN_AUDIENCE.Value,
                SigningCredentials = signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        private static byte[] CreateSymmetricKey(string secret)
        {
            var sha256 = new SHA256Managed();
            var bytes = StringToByteArray(secret);
            return sha256.ComputeHash(bytes);
        }

        private static byte[] StringToByteArray(string str)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }
    }
}