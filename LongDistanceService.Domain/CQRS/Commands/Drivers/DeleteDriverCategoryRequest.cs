using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Drivers;

public record DeleteDriverCategoryRequest(int Id) : IRequest<bool>;