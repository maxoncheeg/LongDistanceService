namespace LongDistanceService.Domain.Models.Abstract;

public interface IMenuItem
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string? Route { get; set; }
    public int Order { get; set; }
    public string? Dll { get; set; }
    public IList<IMenuItem>? Children { get; set; }

}