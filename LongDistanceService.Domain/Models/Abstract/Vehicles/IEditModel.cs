namespace LongDistanceService.Domain.Models.Abstract.Vehicles;

public interface IEditModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
}