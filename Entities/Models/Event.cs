using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly EventDate { get; set; }

    public DateTime EventStartTime { get; set; }

    public DateTime EventEndTime { get; set; }

    public string? OrderType { get; set; }

    public bool? Isac { get; set; }

    public int Noofperson { get; set; }

    public string? SpecialInstruction { get; set; }

    public string? BillingAddress { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ModifiedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string? EventType { get; set; }

    public bool? IsDeleted { get; set; }

    public string? EventStatus { get; set; }

    public virtual Customer? Customer { get; set; }
}
