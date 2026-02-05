using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using netcore_template.Models;

namespace netcore_template.Services.IServices
{
    public interface IJwtService
    {
        string BuildToken(IEnumerable<Claim> claims, JwtOptions options);
    }
}