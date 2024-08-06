using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FlixHub.Data;
using FlixHub.DTO.MovieDTO;
using FlixHub.Models;

namespace FlixHub.Repository.MovieRepo
{
    public class UserMoviesRepository : IUserMoviesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserMoviesRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MovieDetailsDTO>> GetAsync()
        {
            var details = await _context.Movies.ToListAsync();
            
            return _mapper.Map<IEnumerable<MovieDetailsDTO>>(details);
        }

        public async Task<MovieDetailsDTO> GetByNameAsync(string name)
        {
            var details = await _context.Movies.FirstOrDefaultAsync(u => u.Name.Equals(name));
            if (details == null) { return null; }
            return _mapper.Map<MovieDetailsDTO>(details);
        }
    }
}
