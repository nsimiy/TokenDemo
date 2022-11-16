using System.ComponentModel.DataAnnotations;

namespace TokenDemo.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
    }
}
