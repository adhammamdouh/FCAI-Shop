using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FCAI_Shop.DbAccess;

namespace FCAI_Shop.Services
{
    public interface IUserService
    {
        string Authenticate(string username, string password, DateTime expires);
        bool UserExists(int id);
    }
    public class UserService : IUserService
    {
        private readonly JWTSettings _appSettings;

        public UserService(IOptions<JWTSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public bool UserExists(int id)
        {
            return ApplicationUserManager.UserExists(id);
        }

        public string Authenticate(string username, string password, DateTime expires)
        {
            var user = ApplicationUserManager.ValidateUser(username, password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

    }
}
