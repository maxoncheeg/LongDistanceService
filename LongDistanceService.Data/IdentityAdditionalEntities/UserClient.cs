using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Enums;

namespace LongDistanceService.Data.IdentityAdditionalEntities;

public class UserClient : IEntity
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }
    public int ClientId { get; set; }
    public ClientTypes ClientType { get; set; }
}