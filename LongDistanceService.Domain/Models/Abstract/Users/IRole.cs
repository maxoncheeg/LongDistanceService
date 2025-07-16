using System.Text.Json.Serialization;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface IRole
{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Roles Type { get; set; }
}