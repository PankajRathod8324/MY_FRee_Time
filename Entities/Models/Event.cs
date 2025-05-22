using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class Event
{
    public int EventId { get; set; }

    // CustomerId is optional, so no Required attribute here
    public int? CustomerId { get; set; }

    [Required(ErrorMessage = "EventDate is required.")]
    [DataType(DataType.Date, ErrorMessage = "EventDate must be a valid date.")]
    public DateOnly EventDate { get; set; }

    [Required(ErrorMessage = "EventStartTime is required.")]
    [DataType(DataType.Time, ErrorMessage = "EventStartTime must be a valid time.")]
    public DateTime EventStartTime { get; set; }

    [Required(ErrorMessage = "EventEndTime is required.")]
    [DataType(DataType.Time, ErrorMessage = "EventEndTime must be a valid time.")]
    [CustomValidation(typeof(Event), nameof(ValidateEndTime))]
    public DateTime EventEndTime { get; set; }

    [StringLength(50, ErrorMessage = "OrderType cannot exceed 50 characters.")]
    public string? OrderType { get; set; }

    public bool? Isac { get; set; }

    [Required(ErrorMessage = "Number of persons is required.")]
    [Range(1, 1000, ErrorMessage = "Noofperson must be at least 1 and not exceed 1000.")]
    public int Noofperson { get; set; }

    [StringLength(500, ErrorMessage = "SpecialInstruction cannot exceed 500 characters.")]
    public string? SpecialInstruction { get; set; }

    [StringLength(250, ErrorMessage = "BillingAddress cannot exceed 250 characters.")]
    public string? BillingAddress { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    [StringLength(100, ErrorMessage = "EventType cannot exceed 100 characters.")]
    public string? EventType { get; set; }

    public bool? IsDeleted { get; set; }

    [StringLength(50, ErrorMessage = "EventStatus cannot exceed 50 characters.")]
    public string? EventStatus { get; set; }

    public virtual Customer? Customer { get; set; }


    // Custom validation method for ensuring EventEndTime is after EventStartTime
    public static ValidationResult? ValidateEndTime(DateTime endTime, ValidationContext context)
    {
        var instance = context.ObjectInstance as Event;
        if (instance == null) return ValidationResult.Success;

        if (endTime <= instance.EventStartTime)
        {
            return new ValidationResult("EventEndTime must be after EventStartTime.");
        }

        return ValidationResult.Success;
    }
}
