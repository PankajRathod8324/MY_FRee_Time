using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class Taxis
{
    public int TaxId { get; set; }

    [Required(ErrorMessage = "Tax name is required.")]
    [StringLength(100, ErrorMessage = "Tax name cannot exceed 100 characters.")]
    public string TaxName { get; set; } = null!;

    public bool? IsEnabled { get; set; }

    public bool IsDefault { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Invalid tax type.")]
    public int? TaxTypeId { get; set; }

    [Required(ErrorMessage = "Tax amount is required.")]
    [Range(0.0, 1000000.0, ErrorMessage = "Tax amount must be between 0 and 1,000,000.")]
    [DataType(DataType.Currency)]
    public decimal TaxAmount { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<OrderTax> OrderTaxes { get; } = new List<OrderTax>();

    public virtual TaxType? TaxType { get; set; }
}
