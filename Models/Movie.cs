using System.ComponentModel.DataAnnotations;

namespace FlixHub.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name  { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int TotalTicketsAvailable { get; set; }
        public string? Availability { get; set; } = null!;
        [Required]
        public string? Genre { get; set; }

        public string? MovieUrl { get; set; }
        public double Price { get; set; }
        public ICollection<Booking> Bookings { get; set;} = null!;

    }
}