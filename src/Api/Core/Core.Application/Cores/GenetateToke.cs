using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Application.Cores
{
    public static class GenetateToke
    {
        public static string GenerateTokes(IConfiguration configuration, Claim[] claims)
        {


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is test for uk"));
            var creads = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expries = DateTime.Now.AddDays(10);
            var toke = new JwtSecurityToken(null, null, claims: claims, expires: expries, signingCredentials: creads, notBefore: DateTime.Now);
            return new JwtSecurityTokenHandler().WriteToken(toke);
        }

    }
}
