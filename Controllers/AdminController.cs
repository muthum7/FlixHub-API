using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlixHub.Data;
using FlixHub.Models;
using FlixHub.DTO.MovieDTO;
using FlixHub.Repository.AdminRepo;
using FlixHub.DTO.TheatreDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using FlixHub.DTO.UserDTO;


namespace FlixHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromForm] MovieRequestDTO movieRequestDTO)
        {
            if (movieRequestDTO == null) { return null; }
            var movie = await _adminRepository.InsertAsync(movieRequestDTO);
            return Ok(movie);
        }
        [HttpPost("CreateTheatre")]
        public async Task<IActionResult> CreateTheatre([FromForm] TheatreRequestDTO theatreRequestDTO)
        {
            if (theatreRequestDTO == null) { return null; }
            var theatre = await _adminRepository.InsertAsync(theatreRequestDTO);
            return Ok(theatre);
        }

        [HttpGet("ViewAllMovies")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<MovieDetailsDTO>> GetAllMovies()
        {
            var getAll = await _adminRepository.GetAllMovieAsync();
            return getAll;
        }
        [HttpGet("ViewAllTheatres")]
        public async Task<IEnumerable<TheatreDetailsDTO>> GetAllTheatres()
        {
            var getAll = await _adminRepository.GetAllTheatreAsync();
            return getAll;
        }

        [HttpGet("movie/{id:int}", Name = "GetMovieById")]
        public async Task<MovieDetailsDTO> GetMovieById(int id)
        {
            var getmovie = await _adminRepository.GetMovieDetailsByIdAsync(id);
            return getmovie;
        }
        [HttpGet("theatre/{id:int}", Name = "GetTheatreByName")]
        public async Task<TheatreDetailsDTO> GetTheatreById(int id)
        {
            var getTheatre = await _adminRepository.GetTheatreDetailsByIdAsync(id);
            return getTheatre;
        }

        [HttpDelete("movie/{id:int}", Name = "DeleteMovieById")]
        public async Task<IActionResult> DeleteMovieById(int id)
        {
            bool result = await _adminRepository.DeleteMovieByIdAsync(id);
            return Ok(result);
        }
        [HttpPut("movie/{id:int}")]
        public async Task<IActionResult> UpdateMovieById(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var res = await _adminRepository.UpdateMoviesById(id, movieUpdateDTO);
            return Ok(res);
        }
        [HttpPut("theatre/{id:int}")]
        public async Task<IActionResult> UpdateTheatreById(int id, TheatreRequestDTO theatreRequestDTO)
        {
            var res = await _adminRepository.UpdateTheatresById(id, theatreRequestDTO);
            return Ok(res);
        }
        [HttpDelete("theatre/{id:int}", Name = "DeleteTheatreByName")]
        public async Task<IActionResult> DeleteTheatreById(int id)
        {
            bool result = await _adminRepository.DeleteTheatreByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> GetAllUsers(string username, string password)
        {
            if (username.Equals(Admin.UserName))
            {
                if (password.Equals(Admin.Password))
                {
                    var getall = await _adminRepository.GetUserAsync();
                    return Ok(getall);
                }
                else
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }
        [HttpGet("User/{id:int}")]
        public async Task<UserResponseDTO> GetUserById(int id)
        {
            var user = await _adminRepository.UserById(id);

            return user;
        }

    }

}
