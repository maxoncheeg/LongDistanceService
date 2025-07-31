namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface IUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool IsExternalUser { get; set; }
    public IList<IRole> Roles { get; set; }
}