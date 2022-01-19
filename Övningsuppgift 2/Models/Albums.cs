using System.ComponentModel.DataAnnotations;


namespace Övningsuppgift_2.Models
{
    public class Albums
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
