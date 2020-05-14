using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Namotion.Reflection;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> user;
        private readonly SignInManager<ApplicationUser> signInManager;
        

        public AccountApiController(UserManager<ApplicationUser> user
            , SignInManager<ApplicationUser> signInManager,
            IMapper mapper,
           Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.user = user;
            this.signInManager = signInManager;
            Mapper = mapper;
            Configuration = configuration;
        }

        public IMapper Mapper { get; }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        [HttpPost]
        [Route(template:"Register")]
        public async Task<IActionResult> Registration(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              ApplicationUser user=   this.Mapper.Map<RegistrationViewModel, ApplicationUser>(viewModel);
              IdentityResult result = await  this.user.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    return Ok("The User is Created");
                }
                else
                {
                    return BadRequest("The User don't created");
                }


            }

            return Ok();
        }
        [HttpPost(template: "Login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userToken = await user.FindByNameAsync(viewModel.UserName);

                if (userToken != null)
                {


                    var result = await signInManager.CheckPasswordSignInAsync(userToken, viewModel.Password, false);
                    if (result.Succeeded)
                    {
                        var Claims = new List<Claim>()
                        {
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userToken.Email),
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, userToken.PhoneNumber),
                            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName,userToken.UserName)

                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Token:key"]));
                        var creditional = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var Token = new JwtSecurityToken(
                           issuer: this.Configuration["Token:Issuar"],
                           audience: this.Configuration["Token:Audius"],
                           claims: Claims,
                            expires: DateTime.Now.AddHours(3),
                            signingCredentials: creditional);

                        var tokenresult = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(Token),
                            exp = Token.ValidTo

                        };

                        return Created("", tokenresult);




                    }

                }

            }

            return BadRequest("The User is not Exist ");
        }
    }
}