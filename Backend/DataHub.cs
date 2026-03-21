using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs;

public class DataHub : Hub
{
    // This allows the server to broadcast to all connected clients
    public async Task BroadcastMessage(string data)
    {
        await Clients.All.SendAsync("ReceiveData", data);
    }
}