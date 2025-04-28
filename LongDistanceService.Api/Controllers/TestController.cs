using System.Diagnostics;
using LongDistanceService.Api.Controllers.Abstract;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class TestTruck
{
    /// <summary>
    /// Идентификатор тестового трака
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название тестового трака
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Цвет трака. Желательно использовать БЛАГОРОДНЫЕ цвета
    /// </summary>
    public string Color { get; set; }
    /// <summary>
    /// URL картинки приемлемого качества из интернетов
    /// </summary>
    public string Image { get; set; }
}

public class TestController(IVehicleService vehicleService) : AbstractController
{
    private static readonly ActivitySource ActivitySource = new("TestController");

    static List<TestTruck> trucks =
    [
        new()
        {
            Id = 1, Name = "Man", Color = "Шоколадный",
            Image = @"https://i.ytimg.com/vi/QFshYicw8p0/maxresdefault.jpg"
        },
        new()
        {
            Id = 2, Name = "Газель", Color = "Благородная золотая",
            Image = @"https://avatars.mds.yandex.net/get-autoru-vos/2079997/666887c28db232c7da9a23c19308f46b/1200x900"
        },
        new()
        {
            Id = 3, Name = "Нива", Color = "Платина",
            Image = @"https://s.auto.drom.ru/i24223/s/checked/3903731/22103646.jpg"
        },
    ];

    private Random _random = new Random();

    [HttpGet(ServiceRoutes.Test.Base)]
    public IActionResult Index()
    {
        return BaseResponse(200, "test");
    }


    [HttpGet(ServiceRoutes.Test.GetRandomNumber)]
    public async Task<IActionResult> GetRandomNumberAsync()
    {
        return BaseResponse(200, _random.Next(1, 1000));
    }

    [HttpGet(ServiceRoutes.Test.GetAgeByYear)]
    public async Task<IActionResult> GetAgeByYearAsync(string year)
    {
        if (!int.TryParse(year, out int result))
        {
            return BaseResponse(StatusCodes.Status400BadRequest, null);
        }

        //await Task.Delay(_random.Next(500, 2000));
        using var activity = ActivitySource.StartActivity("PossibleTimeLoss", ActivityKind.Server);
        if (activity != null)
        {
            activity.Start();
            await Task.Delay(400);
            activity.Stop();
        }

        return BaseResponse(200, "примерна: " + (DateTime.Now.Year - result));
    }

    [HttpGet(ServiceRoutes.Test.GetTestTrucks)]
    public async Task<IActionResult> GetTestTrucks()
    {
        var vehicles = await vehicleService.GetVehiclesAsync();
        var testTrucks = vehicles.Select(v => new TestTruck()
        {
            Id = v.Id,
            Color = v.LicensePlate,
            Image = v.ImagePath ?? "none",
            Name = v.BrandAndModel
        }).ToList();
        
        return BaseResponse(StatusCodes.Status200OK, testTrucks);
    }

    /// <summary>
    /// Создание трака
    /// </summary>
    /// <param name="truck">Тестовый трак</param>
    /// <returns></returns>
    [HttpPost(ServiceRoutes.Test.CreateTestTruck)]
    public async Task<IActionResult> GetTestTrucks([FromBody] TestTruck truck)
    {
        int nextId = trucks.Max(t => t.Id) + 1;
        truck.Id = nextId;
        trucks.Add(truck);

        return BaseResponse(StatusCodes.Status200OK, null);
    }
}