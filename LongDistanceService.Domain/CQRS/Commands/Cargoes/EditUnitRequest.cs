using LongDistanceService.Domain.Models.Abstract.Cargoes;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public class EditUnitRequest : IRequest<bool>, IUnit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}