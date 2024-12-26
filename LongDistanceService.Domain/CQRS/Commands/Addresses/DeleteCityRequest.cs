using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Addresses;

public class DeleteCityRequest: IRequest<bool>
{
    public int Id { get; set; }
}
