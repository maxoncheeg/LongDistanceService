using LongDistanceService.Data.Contexts;
using MediatR;

namespace LongDistanceService.Shared.DependencyInjection;

public interface ITestService
{
    public void Init();

    public ApplicationDbContext GetC();
    public IMediator GetM();
}

public class TestService(ApplicationDbContext context, IMediator mediator) : ITestService
{
    public void Init()
    {
        Console.WriteLine("HELLO DATABASE!");
    }

    public ApplicationDbContext GetC() => context;

    public IMediator GetM() => mediator;

}