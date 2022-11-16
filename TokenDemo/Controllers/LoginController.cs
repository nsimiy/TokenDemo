using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenDemo.App_Repositories.User_Account;
using TokenDemo.Data;
using TokenDemo.Models;

namespace TokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenDbContext _tokenDbContext;
        private readonly IConfiguration _configuration;

        public LoginController(TokenDbContext tokenDbContext, IConfiguration configuration)
        {
            _tokenDbContext = tokenDbContext;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(UserLogin login)
        {
            var user= _tokenDbContext.Beta.Where(x=>x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new[]
                   {
                      new Claim ("EmailAddress", user.EmailAddress!=null?user.EmailAddress:""),
                      new Claim ("SurName", user.SurName!=null?user.SurName:""),
                      new Claim ("GivenName", user.GivenName!=null?user.GivenName:""),
                      new Claim ("Role", user.Role!=null?user.Role:""),

                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
              signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
