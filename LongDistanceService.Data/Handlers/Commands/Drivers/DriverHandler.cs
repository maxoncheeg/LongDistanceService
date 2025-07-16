using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Drivers;
using LongDistanceService.Domain.CQRS.Commands.Drivers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Drivers;

public class DriverHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteDriverRequest, bool>, IRequestHandler<EditDriverRequest, bool>
{
    public async Task<bool> Handle(DeleteDriverRequest request, CancellationToken cancellationToken)
    {
        var driver = await context.Drivers.Where(d => d.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

        if (driver is not null)
        {
            try
            {
                context.Delete(driver);
                await context.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        return false;
    }

    public async Task<bool> Handle(EditDriverRequest request, CancellationToken cancellationToken)
    {
        var driver = await context.Drivers.Include(d => d.Category).Where(d => d.Id == request.Id)
                         .SingleOrDefaultAsync(cancellationToken)
                     ?? new Driver();
        var category = await context.DriverCategories.Where(d => d.Id == request.CategoryId).SingleOrDefaultAsync(cancellationToken);
        
        if (category == null) return false;
        
        driver.Category = category;
        driver.Experience = request.Experience;
        driver.Name = request.Name;
        driver.Surname = request.Surname;
        driver.Patronymic = request.Patronymic;
        driver.Class = request.Class;
        driver.EmployeeNumber = request.EmployeeNumber;
        driver.BirthYear = request.BirthYear;

        try
        {
            if (request.Id == 0)
                await context.CreateAsync(driver);
            else
                context.Update(driver);

            await context.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}