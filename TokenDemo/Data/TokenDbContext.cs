using Microsoft.EntityFrameworkCore;
using TokenDemo.Models;

namespace TokenDemo.Data
{
    public class TokenDbContext : DbContext
    {
        public TokenDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Omega {get; set;}
        public DbSet<User> Beta { get; set; }
    }
}
