using System.ComponentModel.DataAnnotations;
using BlogRazor.Models;

namespace BlogRazor.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string? Text { get; set; }
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }

}
