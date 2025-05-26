using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class MenuModifierGroupVM
    {
        public IEnumerable<MenuModifierGroup>? menuModifierGroups { get; set; }

        public List<ItemModifierVM>? itemModifierGroups { get; set; }

        public List<int> ModifierIds { get; set; } = new List<int>();

        public List<ModifierVM> Modifiers { get; set; } = new List<ModifierVM>();

        [Required(ErrorMessage = "Modifier Group ID is required")]
        public int ModifierGroupId { get; set; }

        [Required(ErrorMessage = "Item ID is required")]
        public int ItemId { get; set; }

        public List<int> ModifierGroupIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "Modifier Group Name is required")]
        [StringLength(50, ErrorMessage = "Modifier Group Name cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "Modifier Group Name can contain only letters, numbers, spaces, and hyphens")]
        public string ModifierGroupName { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Modifier Group Description cannot exceed 255 characters")]
        public string ModifierGroupDecription { get; set; } = null!;

        public bool? IsDeleted { get; set; }

        public List<MenuModifierGroupVM>? menuModifiers { get; set; }

        public IPagedList<MenuModifierGroupVM>? Modifier { get; set; }

        [Required(ErrorMessage = "Modifier ID is required")]
        public int ModifierId { get; set; }

        [Required(ErrorMessage = "Minimum selection is required")]
        [Range(0, 100, ErrorMessage = "Minimum selection must be between 0 and 100")]
        public int MinSelection { get; set; }

        [Required(ErrorMessage = "Maximum selection is required")]
        [Range(1, 100, ErrorMessage = "Maximum selection must be between 1 and 100")]
        [CustomValidation(typeof(MenuModifierGroupVM), nameof(ValidateMinMaxSelection))]
        public int MaxSelection { get; set; }

        [Required(ErrorMessage = "Modifier Name is required")]
        [StringLength(50, ErrorMessage = "Modifier Name cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z0-9\s\-]+$", ErrorMessage = "Modifier Name can contain only letters, numbers, spaces, and hyphens")]
        public string ModifierName { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Item Instruction cannot exceed 255 characters")]
        public string ItemInstruction { get; set; } = null!;

        [Range(0.0, 9999.99, ErrorMessage = "Modifier Rate must be between 0 and 9999.99")]
        public decimal? ModifierRate { get; set; }

        public int? CategoryId { get; set; }

        public int? UnitId { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }

        [StringLength(255, ErrorMessage = "Modifier Description cannot exceed 255 characters")]
        public string ModifierDecription { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Unit Name cannot exceed 50 characters")]
        public string? UnitName { get; set; }

        // --- Custom validation for Min < Max ---
        public static ValidationResult? ValidateMinMaxSelection(int maxSelection, ValidationContext context)
        {
            var instance = context.ObjectInstance as MenuModifierGroupVM;
            if (instance != null && instance.MinSelection > maxSelection)
            {
                return new ValidationResult("Minimum selection cannot be greater than maximum selection");
            }
            return ValidationResult.Success;
        }
    }
}
