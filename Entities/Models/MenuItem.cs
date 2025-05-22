using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class MenuItem
{
    public int ItemId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive number.")]
    public int? CategoryId { get; set; }

    [Required(ErrorMessage = "Item name is required.")]
    [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters.")]
    public string ItemName { get; set; } = null!;

    [Required(ErrorMessage = "Rate is required.")]
    [Range(0.01, 999999.99, ErrorMessage = "Rate must be between 0.01 and 999999.99.")]
    public decimal Rate { get; set; }

    [Range(1, 10000, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Unit ID must be a positive number.")]
    public int? UnitId { get; set; }

    public bool? IsAvailable { get; set; }

    public bool TaxDefault { get; set; }

    [Range(0, 100, ErrorMessage = "Tax percentage must be between 0 and 100.")]
    public decimal TaxPercentage { get; set; }

    [StringLength(20, ErrorMessage = "Short code cannot exceed 20 characters.")]
    public string? ShortCode { get; set; }

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    public string? Description { get; set; }

    [StringLength(255, ErrorMessage = "Category photo path cannot exceed 255 characters.")]
    [Url(ErrorMessage = "Category photo must be a valid URL.")]
    public string? CategoryPhoto { get; set; }

    public bool? IsFavourite { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Modifier group ID must be a positive number.")]
    public int? ModifierGroupId { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ItemType ID must be a positive number.")]
    public int? ItemtypeId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual MenuCategory? Category { get; set; }

    public virtual ICollection<Favourite> Favourites { get; } = new List<Favourite>();

    public virtual ICollection<ItemModifierGroup> ItemModifierGroups { get; } = new List<ItemModifierGroup>();

    public virtual Itemtype? Itemtype { get; set; }

    public virtual MenuModifierGroup? ModifierGroup { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual Unit? Unit { get; set; }
}
