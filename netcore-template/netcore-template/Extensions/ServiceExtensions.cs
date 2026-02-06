using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_template.Models;
using netcore_template.Services;
using netcore_template.Services.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace netcore_template.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,ConfigurationManager config)
        {
            //add jwt
            services.AddScoped<IJwtService, JwtService>();
            JwtOptions jwtOpt = config.GetSection("JWT").Get<JwtOptions>();
            services.AddJWTAuthentication(jwtOpt);
            services.Configure<SwaggerGenOptions>(c =>
            {
                c.AddAuthenticationHeader();
            });

            return services;
        }
    }
}