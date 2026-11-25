using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Poc.Web.Services;

public sealed class ApiClient(HttpClient http)
{
    public Task<ApiInfo?> GetInfoAsync(CancellationToken ct = default) =>
        http.GetFromJsonAsync<ApiInfo>("/api/info", ct);

    public Task<List<MessageDto>?> GetMessagesAsync(CancellationToken ct = default) =>
        http.GetFromJsonAsync<List<MessageDto>>("/api/messages", ct);

    public async Task<MessageDto?> CreateMessageAsync(string text, CancellationToken ct = default)
    {
        var response = await http.PostAsJsonAsync("/api/messages", new CreateMessageRequest(text), ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MessageDto>(cancellationToken: ct);
    }
}

public sealed record ApiInfo(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("environment")] string Environment,
    [property: JsonPropertyName("version")] string Version,
    [property: JsonPropertyName("message")] string Message);

public sealed record MessageDto(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("createdUtc")] DateTime CreatedUtc);

public sealed record CreateMessageRequest(string Text);
