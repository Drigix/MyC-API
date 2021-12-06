

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication1.Data;

namespace WebApplication1
{
    public static class ServiceExtensions
    {
        public static object Enviroment { get; private set; }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q=> q.User.RequireUniqueEmail=true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollecion services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("Jwt");
            var key = Environment.GetEnvironmentVariable("KEY");

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChellengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            )
            .AddJwtBearer(o =>
                {
                    o.TokenValidationParamters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidationIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection())),
                    };
                });
        }
    }
}
