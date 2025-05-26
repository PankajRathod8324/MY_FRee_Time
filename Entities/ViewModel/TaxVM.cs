using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class TaxVM
    {
        public List<Taxis> AllTaxes { get; set; } = new List<Taxis>();

        public IPagedList<Taxis>? Taxes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Tax Id must be a positive integer")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "Tax Name is required")]
        [StringLength(50, ErrorMessage = "Tax Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Tax Name must contain only alphabets and spaces")]
        public string TaxName { get; set; } = null!;

        public bool IsEnabled { get; set; }

        public bool IsDefault { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Tax Type Id must be a positive integer")]
        public int? TaxTypeId { get; set; }

        [Required(ErrorMessage = "Tax Type Name is required")]
        [StringLength(50, ErrorMessage = "Tax Type Name cannot be longer than 50 characters")]
        public string TaxTypeName { get; set; } = null!;

        [Required(ErrorMessage = "Tax Amount is required")]
        [Range(0, 100, ErrorMessage = "Tax Amount must be between 0 and 100")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Tax Amount can contain up to two decimal places")]
        public decimal TaxAmount { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
