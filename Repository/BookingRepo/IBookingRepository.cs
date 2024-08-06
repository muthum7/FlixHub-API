using FlixHub.DTO.BookingDTO;

namespace FlixHub.Repository.BookingRepo
{
    public interface IBookingRepository
    {
        Task<BookingRequestDTO> CreateBooking(BookingRequestDTO bookingRequestDTO);

        Task<List<BookingResponseDTO>> GetAll();

        Task<BookingRequestDTO> CancelBooking(int id);

        Task<List<BookingResponseDTO>> GetBookingById(int userid);

    }
}
