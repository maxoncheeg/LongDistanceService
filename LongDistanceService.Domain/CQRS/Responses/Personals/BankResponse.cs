using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public record BankResponse : IBank
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}