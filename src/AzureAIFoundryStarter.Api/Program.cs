using AzureAIFoundryStarter.Core.Models;
using AzureAIFoundryStarter.Core.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection("AzureAI");

builder.Services.AddSingleton(new AzureAIChatService(
    config["Endpoint"]!,
    config["ApiKey"]!,
    config["Deployment"]!
));

var app = builder.Build();

app.MapPost("/chat", async (AzureAIChatService ai, ChatRequest req) =>
{
    var result = await ai.AskAsync(req.Prompt);
    return Results.Ok(new { response = result });
});

app.MapPost("/chat/stream", async (AzureAIChatService ai, ChatRequest req, HttpResponse response) =>
{
    response.Headers.ContentType = "text/plain";

    await foreach (var chunk in ai.StreamAsync(req.Prompt))
    {
        await response.WriteAsync(chunk);
        await response.Body.FlushAsync();
    }
});

app.Run();