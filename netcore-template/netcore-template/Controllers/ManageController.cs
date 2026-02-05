using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netcore_template.Models;
using netcore_template.Services.IServices;

namespace netcore_template.Controllers
{
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        public ManageController(ILogger<ManageController> logger,
        IConfiguration configuration,
        IJwtService jwtService)
        {
            _logger = logger;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        [HttpGet("GetToken")]
        public string GetToken()
        {
            var jwtopntion = _configuration.GetSection("JWT").Get<JwtOptions>();
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "用户1"));
            claims.Add(new Claim(ClaimTypes.Role, "超级管理员"));
            return _jwtService.BuildToken(claims, jwtopntion);
        }
    }
}