using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.CQRS.Responses.Menus;

public class MenuItemResponse : IMenuItem
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Route { get; set; }
    public int Order { get; set; }
    public string? Dll { get; set; }
    public IList<IMenuItem>? Children { get; set; } = null;
}