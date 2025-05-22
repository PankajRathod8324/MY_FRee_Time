using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class MenuModifierGroup
{
    public int ModifierGroupId { get; set; }

    [Required(ErrorMessage = "Modifier group name is required.")]
    [StringLength(100, ErrorMessage = "Modifier group name cannot exceed 100 characters.")]
    public string ModifierGroupName { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Modifier group description cannot exceed 500 characters.")]
    public string? ModifierGroupDecription { get; set; }

    public bool? IsDeleted { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive number.")]
    public int? CategoryId { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    public virtual MenuCategory? Category { get; set; }

    public virtual ICollection<CombineModifier> CombineModifiers { get; } = new List<CombineModifier>();

    public virtual ICollection<ItemModifierGroup> ItemModifierGroups { get; } = new List<ItemModifierGroup>();

    public virtual ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();

    public virtual ICollection<MenuModifier> MenuModifiers { get; } = new List<MenuModifier>();
}
