using System.ComponentModel.DataAnnotations;

namespace FlixHub.DTO.MovieDTO
{
    public class MovieDetailsDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalTicketsAvailable { get; set; }
        public string? Availability { get; set; }
        public string? Genre { get; set; }

        public double Price { get; set; }
        public string? MovieUrl { get; set; }
    }
}
