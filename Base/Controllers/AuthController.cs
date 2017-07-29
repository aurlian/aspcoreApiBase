using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Base.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace Base.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {

        private UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("register"), HttpPost]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                AppUser user = new AppUser()
                {
                    JoinDate = DateTime.UtcNow,
                    UserName = model.Username,
                    Email = model.Email,
                    IpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString()
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                    return Ok(result);

                return BadRequest(result.Errors);
            }
            catch (Exception e)
            {
                //log errors
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


    }
}