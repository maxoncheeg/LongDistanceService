using LongDistanceService.Domain.Models.Abstract.Cargoes;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public class EditCargoCategoryRequest : IRequest<bool>, IEditCargoCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int UnitId { get; set; }
}