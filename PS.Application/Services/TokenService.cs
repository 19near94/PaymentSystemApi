using Microsoft.IdentityModel.Tokens;
using PS.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PS.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateAccessToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44367",
                audience: "http://localhost:44367",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
