namespace LongDistanceService.Data.Entities.Abstract;

public class AbstractNameEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
}