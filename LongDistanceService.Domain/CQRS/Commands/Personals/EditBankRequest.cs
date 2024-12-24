using LongDistanceService.Domain.Models.Abstract.Personals;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Personals;

public class EditBankRequest : IRequest<bool>, IBank
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}