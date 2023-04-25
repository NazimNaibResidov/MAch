using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Api.Extensions
{
    public static class AuthRegistertions
    {
        public static IServiceCollection RegistertionAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var result = configuration["authConfig:secret"];
            var GetKey = Encoding.ASCII.GetBytes(result);
            var _key = new SymmetricSecurityKey(GetKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = _key
                    };
                });
            return services;
        }
    }
}
