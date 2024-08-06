using System.ComponentModel.DataAnnotations;

namespace FlixHub.DTO.TheatreDTO
{
    public class TheatreDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
