using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FlixHub.Data;
using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.TheatreDTO;
using FlixHub.Models;

namespace FlixHub.Repository.TheatreRepo
{
    public class UserTheatreRepository : IUserTheatreRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserTheatreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TheatreDetailsDTO>> GetAsync()
        {
            var details = await _context.Theatres.ToListAsync();
            return _mapper.Map<IEnumerable<TheatreDetailsDTO>>(details);
        }
        public async Task<TheatreDetailsDTO> GetTheatreByNameAsync(string name)
        {
            var details = await _context.Theatres.FirstOrDefaultAsync(u => u.Name.Equals(name));
            if (details == null) { return null; }
            return _mapper.Map<TheatreDetailsDTO>(details);
        }
    }
}
