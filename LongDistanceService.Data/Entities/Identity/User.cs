using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Personals;

namespace LongDistanceService.Data.Entities.Identity;

public class User : IEntity
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public bool IsEmailVerified { get; set; }
    public int? IndividualId { get; set; }
    public int? LegalId { get; set; }
    
    public Individual Individual { get; set; }
    public Legal Legal { get; set; }
    public IList<Application> Applications { get; set; } = null!;
    public IList<ApplicationMessage> ApplicationMessages { get; set; } = null!;
    public IList<AuthProvider> AuthProviders { get; set; } = null!;
    public IList<UserRole> UserRoles { get; set; } = null!;
    public IList<TwoFactorSecret> TwoFactorSecrets { get; set; } = null!;
}