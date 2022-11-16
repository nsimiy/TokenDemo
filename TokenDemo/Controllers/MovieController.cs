using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenDemo.App_Repositories.Movie_Account;
using TokenDemo.Data;
using TokenDemo.Models;

namespace TokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        private readonly TokenDbContext _tokenDbContext;

        public MovieController(IMovieRepo movieRepo, TokenDbContext tokenDbContext)
        {
            _movieRepo = movieRepo;
            _tokenDbContext = tokenDbContext;
        }
        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();

            try 
            {
                var delete = _movieRepo.Delete(id);
                response.Status = true;
                response.Message = "Delete Successful";
                return BadRequest(response);
            }
            catch 
            {
                response.Status = false;
                response.Message = "Error deleting movie";
                return BadRequest(response);
            }
        }

        [HttpPut("update")]
        public IActionResult update([FromBody] Movie movie)
        {
            Response response = new Response();
            _movieRepo.Update(movie);
            response.Status = true;
            response.Message = "Update Successful";
            return new OkObjectResult(response);
        }
    }
}
