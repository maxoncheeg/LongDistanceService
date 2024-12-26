using LongDistanceService.Domain.Models.Abstract.Addresses;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Addresses;

public class EditCityRequest : IRequest<bool>, ICity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}