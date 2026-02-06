using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace netcore_template.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            _logger.LogInformation("enter index api.");
            return new JsonResult("Index");
        }

        [HttpGet("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            _logger.LogInformation("enter error api.");
            throw new Exception("add error");
            return new JsonResult("Error");
        }
    }
}