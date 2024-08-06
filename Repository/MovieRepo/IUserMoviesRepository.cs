using FlixHub.DTO.MovieDTO;
using FlixHub.Models;

namespace FlixHub.Repository.MovieRepo
{
    public interface IUserMoviesRepository
    {
        Task<IEnumerable<MovieDetailsDTO>> GetAsync();

        Task<MovieDetailsDTO> GetByNameAsync(string name);
    }

}
