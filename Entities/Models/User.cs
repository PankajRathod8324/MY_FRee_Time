using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(30, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 30 characters.")]
    public string Username { get; set; } = null!;

    public int? RoleId { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string Phone { get; set; } = null!;

    [StringLength(255, ErrorMessage = "Profile photo path cannot exceed 255 characters.")]
    public string? ProfilePhoto { get; set; }

    [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    [StringLength(10, ErrorMessage = "Zipcode cannot exceed 10 characters.")]
    public string? Zipcode { get; set; }

    public int? CreatedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? LastLogin { get; set; }

    [StringLength(100, ErrorMessage = "Reset token cannot exceed 100 characters.")]
    public string? ResetToken { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? ResetTokenExpirytime { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Favourite> Favourites { get; } = new List<Favourite>();

    public virtual Role? Role { get; set; }

    public virtual State? State { get; set; }
}
