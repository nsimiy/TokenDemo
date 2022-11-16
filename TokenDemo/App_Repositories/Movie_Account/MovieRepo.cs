using TokenDemo.Data;
using TokenDemo.Models;

namespace TokenDemo.App_Repositories.Movie_Account
{
    public class MovieRepo : IMovieRepo
    {
        private readonly TokenDbContext _tokenDbContext;

        public MovieRepo(TokenDbContext tokenDbContext)
        {
            _tokenDbContext = tokenDbContext;
        }
        public Movie Create(Movie movie)
        {
            _tokenDbContext.Omega.Add(movie);
            _tokenDbContext.SaveChanges();
            return movie;
        }

        public Movie Delete(int id)
        {
            var delete = _tokenDbContext.Omega.Find(id);
            _tokenDbContext.Omega.Remove(delete);
            _tokenDbContext.SaveChanges();
            return delete;
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> List()
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie movie)
        {
          var Movie = _tokenDbContext.Omega.FirstOrDefault(x => x.Id == movie.Id);
          if(movie == null) 
            {
                movie.Title = movie.Title;
                movie.Description = movie.Description;
                movie.Rating = movie.Rating;

                _tokenDbContext.SaveChanges();
                return movie;
            }
            return null;
        }
    }
}
