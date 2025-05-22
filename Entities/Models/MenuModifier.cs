using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class MenuModifier
{
    public int ModifierId { get; set; }

    [Required(ErrorMessage = "Modifier name is required.")]
    [StringLength(100, ErrorMessage = "Modifier name cannot exceed 100 characters.")]
    public string ModifierName { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "Modifier group ID must be a positive number.")]
    public int? ModifierGroupId { get; set; }

    [Range(0, 99999.99, ErrorMessage = "Modifier rate must be between 0 and 99999.99.")]
    [DataType(DataType.Currency)]
    public decimal? ModifierRate { get; set; }

    public bool? IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Unit ID must be a positive number.")]
    public int? UnitId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Modifier description is required.")]
    [StringLength(500, ErrorMessage = "Modifier description cannot exceed 500 characters.")]
    public string ModifierDecription { get; set; } = null!;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<CombineModifier> CombineModifiers { get; } = new List<CombineModifier>();

    public virtual MenuModifierGroup? ModifierGroup { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<OrderModifier> OrderModifiers { get; } = new List<OrderModifier>();

    public virtual Unit? Unit { get; set; }
}
