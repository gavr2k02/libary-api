using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APILibary.Services;
using APILibary.Models;
using System.Threading.Tasks;

namespace APILibary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }

        [HttpPost]
        [Route("password")]
        public ActionResult signInWithPassword([FromBody] User user)
        {
            try
            {
                string token = this._userService.signInWithPassword(user);
                return StatusCode(200, token);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        [Route("password/create")]
        public async Task<ActionResult> addUser([FromBody] User user)
        {
            try
            {
                string token = await this._userService.addUser(user);
                return StatusCode(200, token);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
