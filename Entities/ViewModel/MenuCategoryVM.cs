using System.ComponentModel.DataAnnotations;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Entities.ViewModel
{
    public class MenuCategoryVM
    {
        public IEnumerable<MenuCategory>? menuCategories { get; set; }

        public IPagedList<MenuItem>? menuItems { get; set; }

        public MenuItem OrderItem { get; set; } = new MenuItem();

        public List<ItemModifierVM> ModifierGroupIds { get; set; } = new List<ItemModifierVM>();

        public List<OrderTaxVM> OrderTax { get; set; } = new List<OrderTaxVM>();

        public List<int> ModifierGroupIdForAdd { get; set; } = new List<int>();

        public List<MenuModifierGroupVM> MenuItemModifier { get; set; } = new List<MenuModifierGroupVM>();

        public List<TaxVM> OrderTaxes { get; set; } = new List<TaxVM>();

        public List<TaxVM> IsDefaultTaxes { get; set; } = new List<TaxVM>();

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
        public string? UId { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [StringLength(100, ErrorMessage = "Item Name cannot exceed 100 characters")]
        [Remote("ValidateItemName", "Menu", AdditionalFields = "ItemId", ErrorMessage = "Item Name already exists")]
        public string ItemName { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Item Instruction cannot exceed 250 characters")]
        public string ItemInstruction { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Order Comment cannot exceed 250 characters")]
        public string OrderComment { get; set; } = null!;

        [Required(ErrorMessage = "Rate is required")]
        [Range(0, 99999.99, ErrorMessage = "Rate must be a positive number")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public int? UnitId { get; set; }

        [Range(0, 999999.99, ErrorMessage = "SubTotal must be a valid amount")]
        public decimal SubTotal { get; set; }

        [Range(0, 999999.99, ErrorMessage = "FinalTotal must be a valid amount")]
        public decimal FinalTotal { get; set; }

        [Range(0, 999999.99, ErrorMessage = "TotalAmount must be a valid amount")]
        public decimal TotalAmount { get; set; }
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }

        public bool? IsSgstInclude { get; set; }

        public bool? IsSgstIncluded { get; set; }
        public string OrderType { get; set; } = null!;

        [Range(0, 100000, ErrorMessage = "SGST Amount must be a positive value")]
        public decimal? SgstAmt { get; set; }

        public bool IsAvailable { get; set; }

        public bool TaxDefault { get; set; }

        [Range(0, 100, ErrorMessage = "Tax Percentage must be between 0 and 100")]
        public decimal TaxPercentage { get; set; }

        [StringLength(20, ErrorMessage = "Short Code cannot exceed 20 characters")]
        public string? ShortCode { get; set; }

        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? Description { get; set; }

        [StringLength(255, ErrorMessage = "Category Photo path is too long")]
        public string? CategoryPhoto { get; set; }

        [StringLength(255, ErrorMessage = "Item Photo path is too long")]
        public string? ItemPhoto { get; set; }

        public bool? IsFavourite { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(50, ErrorMessage = "Category Name cannot be longer than 50 characters")]
        [RegularExpression(@"^(?!\s*$)[A-Za-z\s]+$", ErrorMessage = "Category Name must contain only alphabets and spaces and cannot be empty or spaces only")]
        [Remote("ValidateCategoryName", "Menu", AdditionalFields = "CategoryId", ErrorMessage = "Category already exists")]
        public string CategoryName { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Category Description cannot exceed 200 characters")]
        public string? CategoryDescription { get; set; }

        public List<CustomerTableVM> customerTables { get; set; } = new List<CustomerTableVM>();

        public List<Taxis> Taxes { get; set; } = new List<Taxis>();

        public bool? IsDeleted { get; set; }

        [Range(0, 100, ErrorMessage = "Minimum selection must be between 0 and 100")]
        public int MinSelection { get; set; }

        [Range(0, 100, ErrorMessage = "Maximum selection must be between 0 and 100")]
        public int MaxSelection { get; set; }

        [Required(ErrorMessage = "ItemId is required")]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Item Type is required")]
        public int? ItemtypeId { get; set; }
        [Required(ErrorMessage = "Item Type is required")]
        public string? Itemtype { get; set; }

        public int? ModifierGroupId { get; set; }

        [StringLength(50, ErrorMessage = "Payment Mode Name cannot exceed 50 characters")]
        public string? PaymentModeName { get; set; }
        public string? UnitName { get; set; }
    }
}
