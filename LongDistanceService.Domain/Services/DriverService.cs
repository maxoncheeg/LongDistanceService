using LongDistanceService.Domain.CQRS.Commands.Drivers;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Queries.Drivers;
using LongDistanceService.Domain.Models.Abstract.Drivers;
using LongDistanceService.Domain.Models.Options;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class DriverService(IMediator mediator) : IDriverService
{
    public async Task<IList<IDriverInfo>> GetDriversAsync(int take = 30, int skip = 0, DriverSearchOptions? options = null)
    {
        return [..await mediator.Send(new GetDriversInfoRequest() { Skip = skip, Take = take })];
    }

    public async Task<IDriver?> GetDriverAsync(int id)
    {
        return await mediator.Send(new GetDriverRequest(id));
    }

    public async Task<bool> DeleteDriverAsync(int id)
    {
        return await mediator.Send(new DeleteDriverRequest(id));
    }

    public async Task<bool> AddOrUpdateDriverAsync(IEditDriver driver)
    {
        return await mediator.Send(new EditDriverRequest()
        {
            Id = driver.Id,
            Name = driver.Name,
            Surname = driver.Surname,
            Patronymic = driver.Patronymic,
            BirthYear = driver.BirthYear,
            CategoryId = driver.CategoryId,
            Class = driver.Class,
            EmployeeNumber = driver.EmployeeNumber,
            Experience = driver.Experience
        });
    }

    public async Task<IList<IDriverCategory>> GetDriverCategoriesAsync()
    {
        return [..await mediator.Send(new GetDriverCategoriesRequest())];
    }

    public async Task<bool> AddOrUpdateDriverCategoryAsync(IDriverCategory driverCategory)
    {
        return await mediator.Send(new EditDriverCategoryRequest
            { Id = driverCategory.Id, Name = driverCategory.Name });
    }

    public async Task<bool> DeleteDriverCategoryAsync(int id)
    {
        return await mediator.Send(new DeleteDriverCategoryRequest(id));
    }
}