namespace LongDistanceService.Data.Entities.Abstract;

public abstract class AbstractPersonalEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public string Patronymic { get; set; } = String.Empty;
}