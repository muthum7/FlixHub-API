using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixHub.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8, ErrorMessage = "Password should be 8 character long")]
        public string Password { get; set; } = null!;

        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Password Doesn't Match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Contact information is required")]
        [Range(1111111111, 9999999999, ErrorMessage = "Contact number should be 10 digit long")]
        public long Contact { get; set; }

        public string Role { get; set; } = null!;
        public ICollection<Booking> Bookings { get; set; } = null!;
    }
}