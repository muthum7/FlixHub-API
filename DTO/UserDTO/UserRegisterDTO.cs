using System.ComponentModel.DataAnnotations;

namespace FlixHub.DTO.UserDTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = null!;
                                                          
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(8, ErrorMessage = "Password length should be 8 or greater")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Contact number is required")]
        [Range(1111111111, 9999999999, ErrorMessage = "Contact should be of 10 digit")]
        public long Contact { get; set; }
    }
}
