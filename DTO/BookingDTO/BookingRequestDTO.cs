using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using FlixHub.Models;
using System.ComponentModel.DataAnnotations;

namespace FlixHub.DTO.BookingDTO
{
    public class BookingRequestDTO
    {
        
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
        public int? TheatreId { get; set; }
        public int NumberOfTickets { get; set; }
        public string MovieShowDate { get; set; }
        public DateTime? BookingDate { get; set; }
        public string ShowTime { get; set; }
        public string? PaymentMethods { get; set; }
    }
}
