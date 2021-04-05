
using Banks.BusinessLogic.Interfaces;
using Banks.Entities.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Banks.BusinessLogic
{
    /// <summary>
    /// Service for generate access token.
    /// </summary>
    public class AuthJwtManager : IAuthJwtManager
    {
        private readonly JwtTokenConfig jwtTokenConfig;
       
        /// <summary>
        /// Creates an instance of AuthJwtManager.
        /// </summary>
        /// <param name="jwtTokenConfig">Configuration for access token.</param>
        public AuthJwtManager(IOptions<JwtTokenConfig> jwtTokenConfig)
        {
            this.jwtTokenConfig = jwtTokenConfig.Value;  
        }

        /// <inheritdoc/>      
        public string GenerateToken(User user)
        {
            var now = DateTime.UtcNow;
            var claims = new[]
                    {
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken(
                jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? jwtTokenConfig.Audience : jwtTokenConfig.Issuer,
                claims,
                expires: now.AddMinutes(jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);           
            return accessToken;
        }
    }
}

