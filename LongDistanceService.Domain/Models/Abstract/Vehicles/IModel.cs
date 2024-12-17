namespace LongDistanceService.Domain.Models.Abstract.Vehicles;

public interface IModel
{
    public int Id { get; set; }
    public IBrand Brand { get; set; }
    public string Name { get; set; }
}