using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Responses.Drivers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.DriverCategories;

public class GetDriverCategoriesHandler(IApplicationDbContext context)
    : IRequestHandler<GetDriverCategoriesRequest, IList<DriverCategoryResponse>>
{
    public async Task<IList<DriverCategoryResponse>> Handle(GetDriverCategoriesRequest request,
        CancellationToken cancellationToken)
    {
        var result = context.DriverCategories;

        return await result
            .Select(c => new DriverCategoryResponse() { Id = c.Id, Name = c.Name })
            .ToListAsync(cancellationToken);
    }
}