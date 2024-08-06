using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FlixHub.DTO.BookingDTO;
using FlixHub.Repository.BookingRepo;
using System.Threading.Tasks;
using AutoMapper;

namespace FlixHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;

        public BookingsController(IBookingRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("{uid}/{mid}/{tid}")]
        public async Task<IActionResult> CreateMovieBooking(int uid, int mid, int tid, [FromForm] BookingRequestDTO bookingRequestDTO)
        {
            bookingRequestDTO.UserId = uid;
            bookingRequestDTO.MovieId = mid;
            bookingRequestDTO.TheatreId = tid;
            bookingRequestDTO.BookingDate = DateTime.Now;   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var booking = await _repository.CreateBooking(bookingRequestDTO);

            if (booking == null)
            {
                return BadRequest("Invalid UserId, MovieId, or TheatreId.");
            }
            _mapper.Map<BookingResponseDTO>(booking);   

            return Ok(booking);
        }

        [HttpGet]
        public async Task<IEnumerable<BookingResponseDTO>> GetAllBookings()
        {
            var userdetails = await _repository.GetAll();
            return userdetails;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingById(int id)
        {
            var delbook = await _repository.CancelBooking(id);
            return Ok();
        }
        [HttpGet("{id:int}")]
        public async Task<List<BookingResponseDTO>> GetBookingById(int id)
        {
            var getbook = await _repository.GetBookingById(id);
            return getbook;
        }
    }
}
