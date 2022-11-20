
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HospitalLibrary.Security
{
    public class JwtGenerator
    {
        private readonly string _key = "this is my custom Secret key for authentication";
        private readonly string _issuer = "http://localhost:16177/";
        private readonly string _audience = "http://localhost:4200/";

        public AuthenticationToken GenerateAccessToken(int userId, string role)
        {
            var authenticationToken = new AuthenticationToken();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new("id", userId.ToString()),
                new(ClaimTypes.Role, role)
            };

            var jwt = CreateToken(claims, 60);
            authenticationToken.Id = userId;
            authenticationToken.AccessToken = jwt;

            return authenticationToken;
        }

        private string CreateToken(IEnumerable<Claim> claims, double expirationTime)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
