using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class WaitingList
{
    public int WaitingListId { get; set; }

    [Display(Name = "Waiting Time")]
    public DateTime? WaitingTime { get; set; }

    [Required(ErrorMessage = "Section is required.")]
    public int SectionId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = null!;

    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string? FirstName { get; set; }

    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Number of persons is required.")]
    [Range(1, 100, ErrorMessage = "Number of persons must be between 1 and 100.")]
    public int NoOfPerson { get; set; }

    public int? CreatedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? CreatedAt { get; set; }

    public int? ModifiedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? ModifiedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<CustomerWaiting> CustomerWaitings { get; } = new List<CustomerWaiting>();

    [Required(ErrorMessage = "Section reference is required.")]
    public virtual Section Section { get; set; } = null!;
}
