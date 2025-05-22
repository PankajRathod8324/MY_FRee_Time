using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class MenuCategory
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
    public string CategoryName { get; set; } = null!;

    [StringLength(1000, ErrorMessage = "Category description cannot exceed 1000 characters.")]
    public string? CategoryDescription { get; set; }

    public bool? IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; } = new List<MenuItem>();

    public virtual ICollection<MenuModifierGroup> MenuModifierGroups { get; } = new List<MenuModifierGroup>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
