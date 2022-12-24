using Common.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TOMYCHFinale.Contracts.Response;

namespace TOMYCHFinale.Utils
{
    public static class TokenGenerator 
    {
        public static string JwtGenerator(UserResponse user, string key, string issuer)
        {
            var claims = new Claim[] 
            {
             new Claim(ClaimTypes.Name, user.Email ),
             new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer,
              issuer,
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}";
        }
    }
}
