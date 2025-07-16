using System.Text.Json.Serialization;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public class RoleResponse : IRole
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Roles Type { get; set; }
}