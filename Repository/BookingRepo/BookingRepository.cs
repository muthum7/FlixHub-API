using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FlixHub.Data;
using FlixHub.DTO.BookingDTO;
using FlixHub.Models;
using FlixHub.Repository.MovieRepo;
using System.Threading.Tasks;

namespace FlixHub.Repository.BookingRepo
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookingRequestDTO> CreateBooking(BookingRequestDTO bookingRequestDTO)
        {

            var booking = _mapper.Map<Booking>(bookingRequestDTO);

            var user = await _context.Users.FindAsync(bookingRequestDTO.UserId);
            var movie = await _context.Movies.FindAsync(bookingRequestDTO.MovieId);
            var theatre = await _context.Theatres.FindAsync(bookingRequestDTO.TheatreId);
            


            if (user == null || movie == null || theatre == null)
            {
                return null;
            }


            if (movie.TotalTicketsAvailable > 0)
            {
                movie.TotalTicketsAvailable -= booking.NumberOfTickets;
                booking.NumberOfTickets = bookingRequestDTO.NumberOfTickets;
                booking.TotalAmount = booking.NumberOfTickets * movie.Price;

                _context.Bookings.Add(booking);

                int qty = movie.TotalTicketsAvailable;

                if (qty == 0)
                {
                    movie.Availability = "No Tickets Available";
                }
                string avail = movie.Availability;
                movie.Availability = avail;

            }

            string payment = booking.PaymentMethods;

            if (booking.PaymentMethods == bookingRequestDTO.PaymentMethods)
            {
                booking.PaymentStatus = "Booked";
                booking.PaymentMethods=payment;
            }
            else
            {
                booking.PaymentStatus = "Failed";
            }

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            
            var createdBookingDTO = _mapper.Map<BookingRequestDTO>(booking);
            return createdBookingDTO;
        }
        

        public async Task<BookingRequestDTO> CancelBooking(int id)
        {
            var order = _context.Bookings.Where(u => u.Id == id).FirstOrDefault();
            var movie = _context.Movies.FirstOrDefault(u => u.Id == order.MovieId);
            if (order != null)
            {
                movie.TotalTicketsAvailable += order.NumberOfTickets;
                _context.Bookings.Remove(order);
                

                _context.SaveChanges();
                _mapper.Map<BookingRequestDTO>(order);
                
            }
            return null;

        }

        public async Task<List<BookingResponseDTO>> GetAll()
        {
            var booking = _context.Bookings.Include(o => o.Movie).Include(o => o.Theatre).ToList();
            var movies =  _mapper.Map<List<BookingResponseDTO>>(booking);
            return movies;
           
        }

        public async Task<List<BookingResponseDTO>> GetBookingById(int userId)
        {
            var getbook = _context.Bookings.Include(o => o.Movie).Include(o => o.Theatre).Where(u => u.UserId == userId).ToList() ;
            if (getbook == null) { return null; }
            var booking = _mapper.Map<List<BookingResponseDTO>>(getbook);
            return booking;
        }
    }
}
