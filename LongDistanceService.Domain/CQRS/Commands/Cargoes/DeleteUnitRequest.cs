using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public class DeleteUnitRequest : IRequest<bool>
{
    public int Id { get; set; }
}