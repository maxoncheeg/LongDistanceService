using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public class UserProfileResponse : IUserProfile
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public IList<IRole> Roles { get; set; } = [];
    public IList<string> AuthProviders { get; set; } = [];
    public ISlimIndividual? IndividualInfo { get; set; }
    public ISlimLegal? LegalInfo { get; set; }
}