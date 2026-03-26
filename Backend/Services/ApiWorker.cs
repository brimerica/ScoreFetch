// Backend/Services/ApiWorker.cs
using Microsoft.AspNetCore.SignalR;
using Backend.Hubs;

public class ApiWorker : BackgroundService
{
    private readonly IHubContext<DataHub> _hubContext;
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiWorker(IHubContext<DataHub> hubContext, IHttpClientFactory httpClientFactory)
    {
        _hubContext = hubContext;
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                // Replace with your actual remote API URL
                var response = await client.GetStringAsync("https://ncaa-api.henrygd.me/scoreboard/basketball-men/d1", stoppingToken);

                // Push the raw JSON string to all Svelte clients
                await _hubContext.Clients.All.SendAsync("ReceiveData", response, cancellationToken: stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API Error: {ex.Message}");
            }

            // Poll every 5 seconds (adjust as needed)
            await Task.Delay(5000, stoppingToken);
        }
    }
}