using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HubBookingSystem.Models
{
    public class SignUpViewModel
    {
        [Required]
        [MaxLength(20)]
        [DisplayName("First Name")]
        public required string FirstName { get; set; }
        [DisplayName("Last Name")]
        [MaxLength(20)]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The entered password and confirm password do not match.")]
        public string ConfirmPassword { get; set; } = default!;

    }
}
