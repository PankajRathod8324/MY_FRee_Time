using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class TaxVM
    {
        public List<Taxis> AllTaxes { get; set; }

        public IPagedList<Taxis>? Taxes { get; set; }

        public int TaxId { get; set; }

        [Required(ErrorMessage = "Tax Name is required")]
        [StringLength(50, ErrorMessage = "Tax Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Tax Name must contain only alphabets")]
        public string TaxName { get; set; } = null!;

        public bool IsEnabled { get; set; }

        public bool IsDefault { get; set; }
        public int? TaxTypeId { get; set; }

        public string TaxTypeName { get; set; } = null!;

        [Required(ErrorMessage = "Tax Amount is required")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Tax Amount can contain only numbers")]
        public decimal TaxAmount { get; set; }

        public bool? IsDeleted { get; set; }
    }
}