using FalloutRPDAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FalloutRP.Services
{
    public class TokenConfig
    {
        public string Signature { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }

    public class TokenService
    {
        private readonly TokenConfig _config;

        public TokenService(TokenConfig config)
        {
            _config = config;
        }

        public string TokenCreate(Player player)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config.Issuer,
                claims: ClaimsCreate(player),
                expires: DateTime.Now.AddDays(10),
                signingCredentials: CredentialsCreate()
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SigningCredentials CredentialsCreate()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature)),
                SecurityAlgorithms.HmacSha512Signature
            );
        }

        private IEnumerable<Claim> ClaimsCreate(Player player)
        {
            yield return new Claim(ClaimTypes.NameIdentifier, player.Id.ToString(), ClaimValueTypes.Integer);
            yield return new Claim(ClaimTypes.GivenName, player.Pseudo);
            yield return new Claim(ClaimTypes.Role, value: player.Team.Name);
        }
    }
}
