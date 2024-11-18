using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Identity;

public class MenuTab : IEntity
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? DllName { get; set; }
    public string? FunctionName { get; set; } = String.Empty;
    public int Order { get; set; }

    public IList<MenuTabRight> Rights { get; set; } = null!;
}