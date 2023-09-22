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

        /// <summary>
        /// Create the token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>String</returns>
        public string CreateToken(Player player)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config.Issuer,
                claims: CreateClaims(player),
                expires: DateTime.Now.AddDays(10),
                signingCredentials: CreateCredentials()
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Create credentials
        /// </summary>
        /// <returns>SigningCredentials</returns>
        private SigningCredentials CreateCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature)),
                SecurityAlgorithms.HmacSha512Signature
            );
        }

        /// <summary>
        /// Create claims
        /// </summary>
        /// <param name="user"></param>
        /// <returns>List of Claim</returns>
        private IEnumerable<Claim> CreateClaims(Player player)
        {
            yield return new Claim(ClaimTypes.NameIdentifier, player.Id.ToString(), ClaimValueTypes.Integer);
            yield return new Claim(ClaimTypes.GivenName, player.Pseudo);
            yield return new Claim(ClaimTypes.Role, player.Team.Name);
        }
    }
}
