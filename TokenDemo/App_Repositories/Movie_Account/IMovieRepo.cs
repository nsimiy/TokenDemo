using TokenDemo.Models;

namespace TokenDemo.App_Repositories.Movie_Account
{
    public interface IMovieRepo
    {
        public Movie Create(Movie movie);
        public Movie Get(int id);
        public List<Movie> List();

        public Movie Update(Movie movie);
        public Movie Delete(int id);
    }
}
