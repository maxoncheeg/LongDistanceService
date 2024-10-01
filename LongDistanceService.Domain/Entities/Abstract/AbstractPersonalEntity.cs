namespace LongDistanceService.Domain.Entities.Abstract;

public abstract class AbstractPersonalEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
}