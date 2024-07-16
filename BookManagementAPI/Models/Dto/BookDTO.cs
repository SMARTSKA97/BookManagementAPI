using System.ComponentModel.DataAnnotations;

namespace BookManagementAPI.Models.Dto
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required]
        [MaxLength(30)]
        public string Author { get; set; }
        public int Year { get; set; }
        [Required]
        [MaxLength(15)]
        public string Genre { get; set; }
    }
}