using LongDistanceService.Domain.Models.Abstract.Drivers;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Drivers;

public record EditDriverRequest() : IRequest<bool>, IEditDriver
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string EmployeeNumber { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    public int Experience { get; set; }
}