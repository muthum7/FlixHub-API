using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlixHub.Data;
using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.TheatreDTO;
using FlixHub.DTO.UserDTO;
using FlixHub.Models;

namespace FlixHub.Repository.AdminRepo
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        
        public AdminRepository(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _context = context;  
            _mapper = mapper; 
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }
        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            var del = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (del == null) { return false; }
            _context.Movies.Remove(del);
            _context.SaveChanges();
            return true;
            
        }

        public async Task<bool> DeleteTheatreByIdAsync(int id)
        {
            var del = await _context.Theatres.FirstOrDefaultAsync(x => x.Id == id);
            if (del == null) { return false; }
            _context.Theatres.Remove(del);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<MovieDetailsDTO>> GetAllMovieAsync()
        {
            var details = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<MovieDetailsDTO>>(details);
        }

        public async Task<IEnumerable<TheatreDetailsDTO>> GetAllTheatreAsync()
        {
            var details = await _context.Theatres.ToListAsync();
            return _mapper.Map<IEnumerable<TheatreDetailsDTO>>(details);
        }

        public async Task<MovieDetailsDTO> GetMovieDetailsByIdAsync(int id)
        {
            var details = await _context.Movies.FirstOrDefaultAsync(u => u.Id == id);
            if (details == null) { return null; }
            return _mapper.Map<MovieDetailsDTO>(details);
        }

        public async Task<TheatreDetailsDTO> GetTheatreDetailsByIdAsync(int id)
        {
            var details = await _context.Theatres.FirstOrDefaultAsync(u => u.Id == id);
            if (details == null) { return null; }
            return _mapper.Map<TheatreDetailsDTO>(details);
        }

        public async Task<IEnumerable<UserResponseDTO>> GetUserAsync()
        {
            var details = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserResponseDTO>>(details);
        }

        public async Task<MovieRequestDTO> InsertAsync(MovieRequestDTO movieRequestDTO)
        {
            var details=_mapper.Map<Movie>(movieRequestDTO);

            if (movieRequestDTO.MovieImage != null)
            {
                var imageurl = SaveImage(movieRequestDTO.MovieImage,movieRequestDTO);
                movieRequestDTO.MovieUrl = imageurl; 
                details.MovieUrl = imageurl;
            }
            if (details.TotalTicketsAvailable > 0){
                details.Availability = "Tickets Available";
            }
            else
            {
                details.Availability = "Tickets Unavailable";
            }


            await _context.Movies.AddAsync(details);

            await _context.SaveChangesAsync();
            return _mapper.Map<MovieRequestDTO>(details);

        }

        public async Task<TheatreRequestDTO> InsertAsync(TheatreRequestDTO theatreRequestDTO)
        {
            var details = _mapper.Map<Theatre>(theatreRequestDTO);
            await _context.Theatres.AddAsync(details);
            await _context.SaveChangesAsync();
            return _mapper.Map<TheatreRequestDTO>(details);
        }

        public async Task<MovieUpdateDTO> UpdateMoviesById(int id, MovieUpdateDTO movieUpdateDTO)
        {
            var currentdetails = await _context.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (currentdetails != null)
            {
                var details = _mapper.Map<Movie>(movieUpdateDTO);
                details.Id = id;
                _context.Movies.Update(details);
                await _context.SaveChangesAsync();
                var movie = _mapper.Map<MovieUpdateDTO>(details);
                return movie;

            }
            return null;
        }
        public async Task<TheatreRequestDTO> UpdateTheatresById(int id, TheatreRequestDTO theatreRequestDTO)
        {
            var currentdetails = await _context.Theatres.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (currentdetails != null)
            {
                var details = _mapper.Map<Theatre>(theatreRequestDTO);
                details.Id = id;
                _context.Theatres.Update(details);
                await _context.SaveChangesAsync();
                var theatre = _mapper.Map<TheatreRequestDTO>(details);
                return theatre;

            }
            return null;
        }
        public string SaveImage(IFormFile imageFile, MovieRequestDTO movieRequestDTO)
        {
            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            var localpath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/movieimages", $"{movieRequestDTO.Name}{Path.GetExtension(imageFile.FileName)}");
            //var filepath = Path.Combine(_imagefolderpath, filename);

            using (var stream = new FileStream(localpath, FileMode.Create))
            {
                imageFile.CopyToAsync(stream);
            }

            return $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/wwwroot/movieimages/{movieRequestDTO.Name}{Path.GetExtension(imageFile.FileName)}";
        }

        public async Task<UserResponseDTO> UserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id ==id);

            var res = _mapper.Map<UserResponseDTO>(user);

            return res;
        }

        
    }
}
