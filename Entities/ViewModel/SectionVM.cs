using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class SectionVM
    {
        public List<Section> AllSections { get; set; } = new List<Section>();

        public IPagedList<Table>? tables { get; set; }

        public List<Table> Tab { get; set; } = new List<Table>();

        public int SectionId { get; set; }

        [Required(ErrorMessage = "Section Name is required")]
        [StringLength(50, ErrorMessage = "Section Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Section Name must contain only alphabets and spaces")]
        public string SectionName { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Section Description cannot be longer than 200 characters")]
        public string SectionDecription { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Table Id must be a positive integer")]
        public int TableId { get; set; }

        [Required(ErrorMessage = "Table Name is required")]
        [StringLength(50, ErrorMessage = "Table Name cannot be longer than 50 characters")]
        public string TableName { get; set; } = null!;

        [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100")]
        public int Capacity { get; set; }

        public int? StatusId { get; set; }

        [StringLength(50, ErrorMessage = "Status Name cannot be longer than 50 characters")]
        public string StatusName { get; set; } = string.Empty;

        public bool? IsDeleted { get; set; }

        [Range(0, 1000, ErrorMessage = "Waiting List must be between 0 and 1000")]
        public int WaitingList { get; set; }
    }
}
