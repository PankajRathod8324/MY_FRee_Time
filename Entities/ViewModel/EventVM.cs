using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModel
{
    public class EventVM
    {
        [Required(ErrorMessage = "Event Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateOnly EventDate { get; set; }

        [Required(ErrorMessage = "Event Type is required")]
        [StringLength(50, ErrorMessage = "Event Type cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Event Type must contain only letters and spaces")]
        [Display(Name = "Event Type")]
        public string? EventType { get; set; }

        [Required(ErrorMessage = "Event Start Time is required")]
        [Display(Name = "Start Time")]
        public TimeOnly EventStartTime { get; set; }

        [Required(ErrorMessage = "Event End Time is required")]
        [Display(Name = "End Time")]
        public TimeOnly EventEndTime { get; set; }

        [Required(ErrorMessage = "Order Type is required")]
        [StringLength(50, ErrorMessage = "Order Type cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Order Type must contain only letters and spaces")]
        [Display(Name = "Order Type")]
        public string? OrderType { get; set; }

        [Required(ErrorMessage = "Number of persons is required")]
        [Range(1, 100, ErrorMessage = "Number of persons must be between 1 and 100")]
        [Display(Name = "Number of Persons")]
        public int Noofperson { get; set; }

        public bool Isac { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone format")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone must be between 10 and 15 digits, optionally starting with '+'")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [StringLength(500, ErrorMessage = "Special instruction cannot exceed 500 characters")]
        [Display(Name = "Special Instructions")]
        public string? SpecialInstruction { get; set; }

        [Required(ErrorMessage = "Billing Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        [RegularExpression(@"^(?!\s*$)[A-Za-z0-9\s,.\-#/]+$", ErrorMessage = "Address contains invalid characters or is empty/whitespace")]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; } = null!;
    }
}
