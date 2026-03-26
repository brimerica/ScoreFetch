using Backend.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SvelteCors", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Your Svelte dev port
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Required for SignalR
    });
});

builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<ApiWorker>(); // This starts your background fetcher

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("SvelteCors");

app.MapHub<DataHub>("/dataHub");

app.Run();