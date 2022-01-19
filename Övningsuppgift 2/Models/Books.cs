using System.ComponentModel.DataAnnotations;

namespace Övningsuppgift_2.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }

    }
}
