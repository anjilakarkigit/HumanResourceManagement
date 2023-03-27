using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;
        
        //Register
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            //now save the model to user entity

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };
            
            //save the user info to user table
            //createAsync is coming from the usermanager class
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Errors.Any())
            {
                //user has been successfully created

                return CreatedAtRoute("GetUser", new { controller = "account", id = user.Id });
            }
            //return Bad Request

            return BadRequest(result.Errors.Select(error => error.Description).ToList());
        }
        
        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(new { error = "Please check email/password format" });

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("username does not exist");

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if (isAuthenticated) return Ok("Username password valid");

            return Unauthorized("username password is invalid");
        }
        //GetUserById
    }
}
