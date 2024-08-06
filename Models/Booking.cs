using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace FlixHub.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int MovieId { get; set; }    
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public int TheatreId { get; set; }
        [ForeignKey("TheatreId")]
        public Theatre? Theatre {get; set; } 
        public DateTime BookingDate { get; set; }
        [Required]
        public int NumberOfTickets { get; set; }
        public string MovieShowDate { get; set; }
        public string? PaymentMethods { get; set; }
        public string ShowTime { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public double TotalAmount { get; set; }

    }
}