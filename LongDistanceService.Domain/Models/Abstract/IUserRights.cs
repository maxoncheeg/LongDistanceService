namespace LongDistanceService.Domain.Models.Abstract;

public interface IUserRights
{
    public bool Read { get; }
    public bool Write { get;}
    public bool Edit { get; }
    public bool Delete { get; }
}