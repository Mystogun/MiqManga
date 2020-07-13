using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiqManga.Data;
using MiqManga.Data.Entities;
using MiqManga.Data.Models.Requests;
using MiqManga.Services;

namespace MiqManga.Controllers
{
    // https://www.miq.com/api/auth
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        // CRUD -> Create Read Update Delete -> Conventions
        // CRUD -> Post   Get  Put    Delete -> Http Methods -> Http Client

        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        // POST : api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email
            };
            var result = _authServices.Register(newUser, request.Password);

            return Ok(result);
        }
        
        // POST : api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var loginResult = _authServices.Login(request.Username, request.Password);
            return Ok(loginResult);
        }

    }
}