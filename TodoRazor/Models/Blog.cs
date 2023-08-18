using BlogRazor.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogRazor.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(5000)]
        public string? Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public List<Comment>? Comments { get; set; }

    }
}
