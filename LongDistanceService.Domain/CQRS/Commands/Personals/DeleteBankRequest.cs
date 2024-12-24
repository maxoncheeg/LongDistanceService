using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Personals;

public class DeleteBankRequest : IRequest<bool>
{
    public int Id { get; set; }
}