using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModel;

public class WaitingListVM
{
    [Range(1, int.MaxValue, ErrorMessage = "WaitingListId must be a positive integer")]
    public int WaitingListId { get; set; }

    [Required(ErrorMessage = "Waiting time is required")]
    [DataType(DataType.DateTime, ErrorMessage = "Invalid Waiting Time format")]
    public DateTime WaitingTime { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    [DataType(DataType.Duration, ErrorMessage = "Invalid duration format")]
    [Range(typeof(TimeSpan), "00:01:00", "23:59:59", ErrorMessage = "Duration must be between 1 minute and 23 hours 59 minutes 59 seconds")]
    public TimeSpan Duration { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SectionId must be a positive integer")]
    public int? SectionId { get; set; }

    [StringLength(100, ErrorMessage = "Section Name cannot exceed 100 characters")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Section Name must contain only alphabets and spaces")]
    public string SectionName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only alphabets and spaces")]
    public string Name { get; set; } = null!;

    [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
    [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "First Name must contain only alphabets and spaces")]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
    [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Last Name must contain only alphabets and spaces")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter a valid 10-digit phone number")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Number of persons is required")]
    [Range(1, 20, ErrorMessage = "Number of persons must be between 1 and 20")]
    public int NoOfPerson { get; set; }

    public bool IsDeleted { get; set; }

    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedAt { get; set; }
}
