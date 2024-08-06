using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.UserDTO;
using FlixHub.DTO.TheatreDTO;

namespace FlixHub.Repository.AdminRepo
{
    public interface IAdminRepository
    {
        Task<IEnumerable<UserResponseDTO>> GetUserAsync();   
        Task<MovieRequestDTO> InsertAsync(MovieRequestDTO movieRequestDTO);
        Task<IEnumerable<MovieDetailsDTO>> GetAllMovieAsync();
        Task<MovieDetailsDTO> GetMovieDetailsByIdAsync(int id);
        Task<bool> DeleteMovieByIdAsync(int id);

        Task<TheatreRequestDTO> InsertAsync(TheatreRequestDTO theatreRequestDTO);
        Task<IEnumerable<TheatreDetailsDTO>> GetAllTheatreAsync();
        Task<TheatreDetailsDTO> GetTheatreDetailsByIdAsync(int id);
        Task<bool> DeleteTheatreByIdAsync(int id);

        Task<MovieUpdateDTO> UpdateMoviesById(int id, MovieUpdateDTO movieRequestDTO);
        Task<TheatreRequestDTO> UpdateTheatresById(int id, TheatreRequestDTO theatreRequestDTO);
        Task<UserResponseDTO> UserById(int id);


    }
}
