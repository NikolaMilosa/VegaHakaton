using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}
