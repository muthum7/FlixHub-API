namespace FlixHub.DTO.UserDTO
{
    public class UserUpdateDTO
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;
        public long Contact { get; set; }
    }
}
