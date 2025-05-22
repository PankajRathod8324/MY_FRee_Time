using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModel
{
    public class EventVM
    {
        [Required(ErrorMessage = "Event Date is required")]
        public DateOnly EventDate { get; set; }

        [Required(ErrorMessage = "Event Type is required")]
        public string? EventType { get; set; }

        [Required(ErrorMessage = "Event Start Time  is required")]
        public TimeOnly EventStartTime { get; set; }

        [Required(ErrorMessage = "Event End Time is required")]
        public TimeOnly EventEndTime { get; set; }

        [Required(ErrorMessage = "Order Type is required")]
        public string? OrderType { get; set; }

        [Required(ErrorMessage = "No Of Person is required")]
        [Range(0, 100, ErrorMessage = "No Of Person must be between 0 and 100")]
        public int Noofperson { get; set; }

        public bool Isac { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }

        public string? SpecialInstruction { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string BillingAddress { get; set; }
    }
}