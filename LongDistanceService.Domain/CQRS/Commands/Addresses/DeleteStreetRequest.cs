using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Addresses;

public class DeleteStreetRequest : IRequest<bool>
{
    public int Id { get; set; }
}