using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Server.Statics;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlahlyMomknTask.Server.Services
{
    public static class TokenHandler
    {
        private const int EXPIRE_HOURS = 2;
        private const int EXPIRE_HOURS_Remember = 24;
        private const string UserIDKey = "UserID";
        private static readonly byte[] Key = Encoding.ASCII.GetBytes(JWTConfigrations.Key);

        public static string CreateToken(User user, bool remember = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(UserIDKey, user.ID.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)

                }),
                Expires = DateTime.UtcNow.AddHours(remember ? EXPIRE_HOURS_Remember : EXPIRE_HOURS),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
