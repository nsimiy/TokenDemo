
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using TokenDemo.App_Repositories.User_Account;
using TokenDemo.Data;
using TokenDemo.Models;
using Response = TokenDemo.Models.Response;

namespace TokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly TokenDbContext _tokenDbContext;

        public UserController(IUserRepo userRepo, TokenDbContext tokenDbContext)
        {
            _userRepo = userRepo;
            _tokenDbContext = tokenDbContext;
        }
        [HttpPost("CreateUser")]
        public IActionResult createUser([FromBody] User user)
        {
            Response response = new Response();
            
                var addUser = _userRepo.createUser(user);
                if (addUser != null)
                {
                    response.Status = true;
                    response.Message = "successful";
                    return new OkObjectResult(response);
                }
                response.Status = false;
                response.Message = "failed";
                return BadRequest(response);

         }
           
        

        [HttpDelete("deleteUser")]
        public IActionResult deleteUser(int id)
        {
            Response response = new Response();
            try
            {
                _userRepo.Delete(id);
                response.Status = true;
                response.Message = "success";
                return BadRequest(response);

            }
            catch
            {
                response.Status = false;
                response.Message = "Error deleting user";
                return BadRequest(response);
            }
        }

        [HttpPut("updateUser")]
        public IActionResult updateUser([FromBody] User user)
        {
            Response response = new Response();
            _userRepo.updateUser(user);
            response.Status = true;
            response.Message = "Update Successful";
            return new OkObjectResult(response);
        }
    }
}
