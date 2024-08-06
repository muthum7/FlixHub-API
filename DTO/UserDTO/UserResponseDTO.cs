namespace FlixHub.DTO.UserDTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public long Contact { get; set; }
        public string Role { get; set; } = null!;
    }
}