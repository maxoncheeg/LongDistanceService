using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface IUserProfile
{
    public int Id { get; set; }
    public string Email { get; set; }
    public IList<IRole> Roles { get; set; }
    public IList<string> AuthProviders { get; set; }
    public ISlimIndividual? IndividualInfo { get; set; }
    public ISlimLegal? LegalInfo { get; set; }
}