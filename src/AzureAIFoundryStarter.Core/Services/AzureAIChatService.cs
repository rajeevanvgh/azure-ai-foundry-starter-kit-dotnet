using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace AzureAIFoundryStarter.Core.Services;

public class AzureAIChatService
{
    private readonly ChatClient _chat;

    public AzureAIChatService(string endpoint, string apiKey, string deployment)
    {
        var client = new AzureOpenAIClient(
            new Uri(endpoint),
            new AzureKeyCredential(apiKey)
        );

        _chat = client.GetChatClient(deployment);
    }

    // -------------------------------
    // Simple Chat Completion
    // -------------------------------
    public async Task<string> AskAsync(string prompt)
    {
        var messages = new List<ChatMessage>
        {
            ChatMessage.CreateUserMessage(prompt)
        };

        var response = await _chat.CompleteChatAsync(messages);
        return response.Value.Content[0].Text;
    }

    // -------------------------------
    // JSON Mode
    // -------------------------------
    public async Task<string> AskJsonAsync(string prompt)
    {
        var messages = new List<ChatMessage>
        {
            ChatMessage.CreateUserMessage(prompt)
        };

        var options = new ChatCompletionOptions
        {
            ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat()
        };

        var response = await _chat.CompleteChatAsync(messages, options);
        return response.Value.Content[0].Text;
    }

    // -------------------------------
    // Streaming
    // -------------------------------
    public async IAsyncEnumerable<string> StreamAsync(string prompt)
    {
        var messages = new List<ChatMessage>
        {
            ChatMessage.CreateUserMessage(prompt)
        };

        await foreach (var update in _chat.CompleteChatStreamingAsync(messages))
        {
            foreach (var part in update.ContentUpdate)
                yield return part.Text;
        }
    }
}