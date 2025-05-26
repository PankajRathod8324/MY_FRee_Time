namespace Entities.ViewModel;
public partial class ModifierVM
{
    public int ModifierId { get; set; }
    public string ModifierName { get; set; } = null!;
    public decimal? ModifierRate { get; set; }
}