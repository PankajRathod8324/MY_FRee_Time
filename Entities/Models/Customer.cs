using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Entities.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; } = null!;

    public int? TableId { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 characters.")]
    [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Phone number can only contain digits and an optional leading '+'.")]
    public string Phone { get; set; } = null!;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Date must be a valid date.")]
    public DateOnly? Date { get; set; }

    [Range(1, 1000, ErrorMessage = "Noofperson must be between 1 and 1000.")]
    public int? Noofperson { get; set; }

    public virtual ICollection<CustomerTable> CustomerTables { get; } = new List<CustomerTable>();

    public virtual ICollection<CustomerWaiting> CustomerWaitings { get; } = new List<CustomerWaiting>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual Table? Table { get; set; }
}
