using LongDistanceService.Data.Contexts;
using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Responses.DriverCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.DriverCategories;

public class GetDriverCategoriesHandler(IApplicationDbContext context)
    : IRequestHandler<GetDriverCategoriesRequest, IList<DriverCategoryResponse>>
{
    public async Task<IList<DriverCategoryResponse>> Handle(GetDriverCategoriesRequest request,
        CancellationToken cancellationToken)
    {
        var result = string.IsNullOrEmpty(request.Search)
            ? context.DriverCategories
            : context.DriverCategories.Where(c =>
                c.Name.Contains(request.Search, StringComparison.InvariantCultureIgnoreCase));

        return await result.Skip(request.Skip)
            .Take(request.Take)
            .Select(c => new DriverCategoryResponse() { Id = c.Id, Name = c.Name })
            .ToListAsync(cancellationToken);
    }
}