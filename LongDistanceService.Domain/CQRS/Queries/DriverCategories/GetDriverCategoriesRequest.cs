using LongDistanceService.Domain.CQRS.Responses.DriverCategories;

namespace LongDistanceService.Domain.CQRS.Queries.DriverCategories;

public record GetDriverCategoriesRequest : ScrolledRequest<DriverCategoryResponse>
{
    
}