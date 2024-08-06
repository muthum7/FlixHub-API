using FlixHub.DTO.TheatreDTO;
using FlixHub.Models;

namespace FlixHub.Repository.TheatreRepo
{
    public interface IUserTheatreRepository
    {

        Task<IEnumerable<TheatreDetailsDTO>> GetAsync();

        Task<TheatreDetailsDTO> GetTheatreByNameAsync(string name);
    }
}
