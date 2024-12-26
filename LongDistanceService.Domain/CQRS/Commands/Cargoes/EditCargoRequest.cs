using LongDistanceService.Domain.Models.Abstract.Cargoes;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public class EditCargoRequest : IRequest<bool>, IEditCargo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
}