using LojaVirtualEstagio.Api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  

namespace LojaVirtualEstagio.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("usuarioId", usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3), //Inspiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenConfig);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
