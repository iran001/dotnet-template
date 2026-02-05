using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using netcore_template.Models;
using netcore_template.Services.IServices;

namespace netcore_template.Services
{
    public class JwtService : IJwtService
    {
        public string BuildToken(IEnumerable<Claim> claims, JwtOptions options)
        {
            //过期时间
            TimeSpan timeSpan = TimeSpan.FromSeconds(options.ExpireSeconds);//token过期时间
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));//加密的token密钥
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);//签名证书，其值为securityKey和HmacSha256Signature算法
            var tokenDescriptor = new JwtSecurityToken(options.Issuer, options.Audience, claims, expires: DateTime.Now.Add(timeSpan), signingCredentials: credentials);//表示jwt token的描述信息，其值包括Issuer签发方，Audience接收方，Claims载荷，过期时间和签名证书
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);//使用该方法转换为字符串形式的jwt token返回
        }
    }
}