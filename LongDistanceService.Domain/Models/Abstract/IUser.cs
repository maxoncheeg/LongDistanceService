namespace LongDistanceService.Domain.Models.Abstract;

public interface IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
}