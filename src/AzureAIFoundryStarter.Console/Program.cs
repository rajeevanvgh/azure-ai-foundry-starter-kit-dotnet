using AzureAIFoundryStarter.Core.Services;

// Simple console runner to quickly test your AzureAIChatService.
// Update the values below with your Azure AI Foundry configuration.

var endpoint = "https://YOUR_RESOURCE_NAME.openai.azure.com/";
var apiKey = "YOUR_API_KEY"; // Or use Azure AD authentication
var deployment = "YOUR_DEPLOYMENT_NAME";

var ai = new AzureAIChatService(endpoint, apiKey, deployment);

Console.WriteLine("Azure AI Foundry – Console Test");
Console.WriteLine("Type your question and press Enter.");
Console.WriteLine();

Console.Write("You: ");
var prompt = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(prompt))
{
    var response = await ai.AskAsync(prompt);

    Console.WriteLine("\nAI Response:");
    Console.WriteLine(response);
}
else
{
    Console.WriteLine("No input provided.");
}