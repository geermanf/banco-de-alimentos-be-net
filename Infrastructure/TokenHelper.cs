using Farmacity.FCDM.BackOffice.Configuration;
using Farmacity.FCDM.BackOffice.Constants;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Farmacity.FCDM.BackOffice.DTOs;

namespace Farmacity.FCDM.BackOffice.Infrastructure
{
    public class TokenHelper
    {
        TokenConfiguration tokenConfiguration;


        public TokenHelper(IConfiguration configuration)
        {
            tokenConfiguration = configuration.GetSection(ConfigurationSections.TokenConfiguration).Get<TokenConfiguration>();
        }

        public  string GenerateToken(InternalUserResponse administrator)
        {
            var issuerSigningKey = tokenConfiguration.IssuerSigningKey;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, administrator.Key),
                new Claim(ClaimTypes.Name, $"{administrator.Email} {administrator.Key}" ),
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: tokenConfiguration.ApiURL, // localhost de este
                audience: tokenConfiguration.WebAppRootURL, // localhost 4200
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenConfiguration.TokenExpirationMinutes),
                signingCredentials: signinCredentials
            );            

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

    }
}
