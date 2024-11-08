using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Enums;

namespace LongDistanceService.Data.IdentityAdditionalEntities;

public class UserClient
{
    public string IdentityUserId { get; set; } = String.Empty;
    public int ClientId { get; set; }
    public ClientTypes ClientType { get; set; }
}