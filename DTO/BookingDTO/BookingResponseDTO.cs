using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.TheatreDTO;
using FlixHub.Models;

namespace FlixHub.DTO.BookingDTO
{
    public class BookingResponseDTO
    {
        public int Id  { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public MovieResponseDTO? Movie { get; set; }
        public int TheatreId { get; set; }

        public TheatreDetailsDTO? Theatre { get; set; }
        public DateTime BookingDate {  get; set; }  
        public string ShowTime { get; set; }
        public string MovieShowDate {  get; set; }
        public int  NumberOfTickets { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public double TotalAmount { get; set; }
    }
}
