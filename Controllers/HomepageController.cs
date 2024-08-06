using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.TheatreDTO;
using FlixHub.Repository.MovieRepo;
using FlixHub.Repository.TheatreRepo;

namespace FlixHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HomepageController : ControllerBase
    {
        private readonly IUserMoviesRepository _userMoviesRepository;
        private readonly IUserTheatreRepository _userTheatreRepository;

        public HomepageController(IUserMoviesRepository userMoviesRepository, IUserTheatreRepository userTheatreRepository)
        {
            _userMoviesRepository = userMoviesRepository;
            _userTheatreRepository = userTheatreRepository;
        }

        [HttpGet("GetAllMovies")]
        public async Task<IEnumerable<MovieDetailsDTO>> GetAllMovies()
        {
            var display = await _userMoviesRepository.GetAsync();

            return display;
        }
        [HttpGet("movie/{name:alpha}")]
        public async Task<MovieDetailsDTO> GetMovieByName(string name)
        {
            var display = await _userMoviesRepository.GetByNameAsync(name);
            return display;
        }

        [HttpGet("GetAllTheatres")]
        public async Task<IEnumerable<TheatreDetailsDTO>> GetAllTheatres()
        {
            var display = await _userTheatreRepository.GetAsync();

            return display;
        }
        [HttpGet("theatre/{name:alpha}")]
        public async Task<TheatreDetailsDTO> GetTheatreByName(string name)
        {
            var display = await _userTheatreRepository.GetTheatreByNameAsync(name);
            return display;
        }
    }
}
