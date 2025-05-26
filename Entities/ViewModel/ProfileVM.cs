using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.ViewModel
{
    public class ProfileVM
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name can only contain letters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name can only contain letters")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+$", ErrorMessage = "User Name can only contain letters, numbers, dots, underscores, and hyphens")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
        public string? PhoneNumber { get; set; }

        [StringLength(255, ErrorMessage = "Profile picture path is too long")]
        public string? ProfilePicture { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Country name must contain only letters")]
        public string? Country { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "State name must contain only letters")]
        public string? State { get; set; }

        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City name must contain only letters")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string? Address { get; set; }
        [StringLength(10, ErrorMessage = "Zip Code cannot be longer than 10 characters")]
        [RegularExpression(@"^[0-9A-Za-z\-]+$", ErrorMessage = "Zip Code can only contain letters, numbers, and hyphens")]
        public string? ZipCode { get; set; }
    }
}
