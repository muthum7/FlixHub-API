using System.ComponentModel.DataAnnotations;

namespace FlixHub.Models
{
    public class Theatre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Location { get; set; }
        public ICollection<Booking> Bookings { get; set; } = null!; 

    }
}