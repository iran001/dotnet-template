using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace netcore_template.Extensions
{
    public static class SwaggerGenOptionsExtensions
    {
        /// <summary>
        /// 为swagger增加Authentication报文头
        /// </summary>
        /// <param name="option"></param>
        public static void AddAuthenticationHeader(this SwaggerGenOptions option)
        {
            option.AddSecurityDefinition("Authorization",
                new OpenApiSecurityScheme
                {
                    Description = "Authorization header. \r\nExample:Bearer 12345ABCDE",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Authorization"
                });

            // option.AddSecurityRequirement((a)=>
            // {
            //     a.Info = new OpenApiInfo { Title = "My API", Version = "v1" };
            //     a.Security = new List<OpenApiSecurityRequirement>
            //     {
            //         new OpenApiSecurityRequirement
            //         {
            //             {
            //                 new OpenApiSecuritySchemeReference("0"),
            //                 new List<string>{}
            //             }
            //         }
            //     };                
            //     return a.Security.First();
            // });


        }
    }
}