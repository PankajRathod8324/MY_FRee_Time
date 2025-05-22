using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModel;

public class UserViewModel
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First Name must contain only alphabets and spaces")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last Name must contain only alphabets and spaces")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "User Name is required")]
    [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters")]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "User Name can contain only letters, numbers, and underscores")]
    public string Username { get; set; } = null!;
    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public string RoleName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,50}$", ErrorMessage = "Password must be at least 6 characters and include at least one letter and one number")]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone Number must be between 10 to 15 digits, optionally starting with '+'")]
    public string Phone { get; set; } = null!;
    public string? ProfilePhoto { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
    [RegularExpression(@"^[A-Za-z0-9\s,.\-#/]+$", ErrorMessage = "Address contains invalid characters")] public string? Address { get; set; }

    [Required(ErrorMessage = "Country is required")]
    public int? CountryId { get; set; }

    [Required(ErrorMessage = "State is required")]
    public int? StateId { get; set; }

    [Required(ErrorMessage = "City is required")]
    public int? CityId { get; set; }

    [Required(ErrorMessage = "Zip Code is required")]
    [StringLength(10, ErrorMessage = "Zip Code cannot be longer than 10 characters")]
    [RegularExpression(@"^\d{4,10}$", ErrorMessage = "Zip Code must be between 4 to 10 digits")]
    public string? Zipcode { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime LastLogin { get; set; }
    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpirytime { get; set; }
}

