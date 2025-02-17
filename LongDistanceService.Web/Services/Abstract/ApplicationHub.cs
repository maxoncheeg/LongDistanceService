using Microsoft.AspNetCore.SignalR;

namespace LongDistanceService.Web.Services.Abstract;

public class ApplicationHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}