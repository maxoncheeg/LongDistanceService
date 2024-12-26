using LongDistanceService.Domain.Models.Abstract.Addresses;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Addresses;

public class EditStreetRequest: IRequest<bool>, IStreet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}