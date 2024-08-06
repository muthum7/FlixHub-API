using System.ComponentModel.DataAnnotations;

namespace FlixHub.DTO.MovieDTO
{
    public class MovieRequestDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int TotalTicketsAvailable { get; set; }
        [Required]
        public string? Genre { get; set; }

        public IFormFile MovieImage { get; set; }
        public string? MovieUrl { get; set; }
        public double Price { get; set; }
    }
}
