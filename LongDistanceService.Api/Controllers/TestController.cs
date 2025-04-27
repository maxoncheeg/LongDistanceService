using System.Diagnostics;
using LongDistanceService.Api.Controllers.Routes;
using Microsoft.AspNetCore.Mvc;

namespace LongDistanceService.Api.Controllers;

public class TestTruck
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Image { get; set; }
}

public class TestController : Controller
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

    [HttpGet(ServiceRoutes.Test)]
    public IActionResult Index()
    {
        return Ok("test");
    }


    [HttpGet(ServiceRoutes.TestRoutes.GetRandomNumber)]
    public async Task<IActionResult> GetRandomNumberAsync()
    {
        return Ok(_random.Next(1000));
    }

    [HttpGet(ServiceRoutes.TestRoutes.GetAgeByYear)]
    public async Task<IActionResult> GetAgeByYearAsync(string year)
    {
        if (!int.TryParse(year, out int result))
        {
            return BadRequest("ГОД НЕ ИНТОВЫЙ!");
        }

        //await Task.Delay(_random.Next(500, 2000));
        using var activity = ActivitySource.StartActivity("PossibleTimeLoss", ActivityKind.Server);
        if (activity != null)
        {
            activity.Start();
            await Task.Delay(400);
            activity.Stop();
        }

        return Ok("примерна: " + (DateTime.Now.Year - result));
    }

    [HttpGet(ServiceRoutes.TestRoutes.GetTestTrucks)]
    public async Task<IActionResult> GetTestTrucks()
    {
        return Ok(trucks);
    }

    [HttpPost(ServiceRoutes.TestRoutes.CreateTestTruck)]
    public async Task<IActionResult> GetTestTrucks([FromBody]TestTruck truck)
    {
        int nextId = trucks.Max(t => t.Id) + 1;
        truck.Id = nextId;
        trucks.Add(truck);
        
        return Ok();
    }
}