using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Drivers;
using LongDistanceService.Domain.CQRS.Commands.Drivers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Drivers;

public class DriverCategoryHandler(IApplicationDbContext context) : IRequestHandler<EditDriverCategoryRequest, bool>,
    IRequestHandler<DeleteDriverCategoryRequest, bool>
{
    public async Task<bool> Handle(EditDriverCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = request.Id != 0
            ? await context.DriverCategories.SingleOrDefaultAsync(b => b.Id == request.Id,
                cancellationToken: cancellationToken)
            : new DriverCategory();

        if (category == null) return false;
        
        try
        {
            category.Name = request.Name;
            context.Update(category);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteDriverCategoryRequest request, CancellationToken cancellationToken)
    {
        var category =
            await context.DriverCategories.SingleOrDefaultAsync(b => b.Id == request.Id,
                cancellationToken: cancellationToken);

        if (category == null) return false;

        try
        {
            context.Delete(category);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
}