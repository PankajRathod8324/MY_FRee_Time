using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class Section
{
    public int SectionId { get; set; }

    [Required(ErrorMessage = "Section name is required.")]
    [StringLength(100, ErrorMessage = "Section name cannot exceed 100 characters.")]
    public string SectionName { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? SectionDecription { get; set; }

    public bool? IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<Table> Tables { get; } = new List<Table>();

    public virtual ICollection<WaitingList> WaitingLists { get; } = new List<WaitingList>();
}
