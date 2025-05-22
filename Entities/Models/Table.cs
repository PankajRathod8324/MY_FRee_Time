using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class Table
{
    public int TableId { get; set; }

    [Required(ErrorMessage = "Table name is required.")]
    [StringLength(50, ErrorMessage = "Table name cannot exceed 50 characters.")]
    public string TableName { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Section ID must be a positive number.")]
    public int? SectionId { get; set; }

    [Required(ErrorMessage = "Capacity is required.")]
    [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100.")]
    public int Capacity { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Status ID must be a positive number.")]
    public int? StatusId { get; set; }

    public bool? IsDeleted { get; set; }

    [DataType(DataType.DateTime, ErrorMessage = "Invalid occupied time format.")]
    public DateTime? OccupiedTime { get; set; }

    public virtual ICollection<CustomerTable> CustomerTables { get; } = new List<CustomerTable>();

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<OrderTable> OrderTables { get; } = new List<OrderTable>();

    public virtual Section? Section { get; set; }

    public virtual TableStatus? Status { get; set; }
}
