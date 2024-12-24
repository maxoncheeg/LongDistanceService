using LongDistanceService.Domain.CQRS.Responses.Drivers;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.DriverCategories;

public record GetDriverCategoriesRequest : IRequest<IList<DriverCategoryResponse>>
{
    
}