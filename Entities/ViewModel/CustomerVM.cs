using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class CustomerVM
    {
        public List<Customer> AllCustomers { get; set; } = new List<Customer>();

        public IPagedList<Customer>? Customers { get; set; }

        public List<OrderVM> Orders { get; set; } = new List<OrderVM>();

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only alphabets and spaces")]
        public string Name { get; set; } = null!;

        public int? TableId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 to 15 digits, optionally starting with '+'")]
        public string Phone { get; set; } = null!;

        [Range(1, 100, ErrorMessage = "Number of persons must be between 1 and 100")]
        public int NoOfPerson { get; set; }

        // [Range(0, int.MaxValue, ErrorMessage = "Total orders must be a non-negative number")]
        public int TotalOrder { get; set; }

        // [Range(0, double.MaxValue, ErrorMessage = "Max order must be a non-negative value")]
        public decimal MaxOrder { get; set; }

        // [Range(0, double.MaxValue, ErrorMessage = "Average order must be a non-negative value")]
        public decimal AverageOrder { get; set; }

        // [Range(0, int.MaxValue, ErrorMessage = "Visits must be a non-negative number")]
        public int Visits { get; set; }

        public DateTime LastVisit { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateOnly? Date { get; set; }

        public int? PaymentModeId { get; set; }
        public string? PaymentMode { get; set; } 
    }
}
