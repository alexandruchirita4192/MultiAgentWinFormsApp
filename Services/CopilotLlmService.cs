// This code was generated in whole or in part by GenAI tool

using System.Text;
using MultiAgentWinFormsApp.Interfaces;
using Newtonsoft.Json;

namespace MultiAgentWinFormsApp.Services;

public class CopilotLlmService : ILLMService
{
    private readonly HttpClient _httpClient;
    public CopilotLlmService(string token)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-Github-Token", token);
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        var payload = new
        {
            model = "github/copilot-llm",
            messages = new[] { new { role = "user", content = prompt } }
        };
        var json = JsonConvert.SerializeObject(payload);
        using var req = new HttpRequestMessage(HttpMethod.Post, "https://api.githubcopilot.com/chat/completions")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        using var resp = await _httpClient.SendAsync(req);
        resp.EnsureSuccessStatusCode();
        var body = await resp.Content.ReadAsStringAsync();
        dynamic result = JsonConvert.DeserializeObject(body);
        return (string)result.choices[0].message.content;
    }
}
