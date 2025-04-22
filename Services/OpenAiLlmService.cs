// This code was generated in whole or in part by GenAI tool

using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Services;

public class OpenAiLlmService : ILLMService
{
    private string apiUrl = "https://api.openai.com/v1/chat/completions";

    private static readonly object _httpClientSync = new Object();
    private readonly HttpClient _httpClient;

    public OpenAiLlmService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        lock (_httpClientSync)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", EnvironmentContext.BackEnd.OpenAIKey);
        }
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        string? body = null;
        try
        {
            if (string.IsNullOrWhiteSpace(prompt))
                throw new ArgumentException("Prompt cannot be null or empty.");

            var payload = new
            {
                model = EnvironmentContext.BackEnd.OpenAIModel,
                messages = new[] { new { role = "user", content = prompt } }
            };

            var json = JsonConvert.SerializeObject(payload);
            using var req = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            using var resp = await _httpClient.SendAsync(req);

            try
            {
                resp.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new NotSupportedException($"Failed to call OpenAI API. OpenAI Response: '{body}'", ex);
            }
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                throw new NotSupportedException($"OpenAI API returned an error. OpenAI Response: '{body}'");

            body = await resp.Content.ReadAsStringAsync();

            var result = !string.IsNullOrWhiteSpace(body)
                ? JsonConvert.DeserializeObject<ResponseModel>(body)
                : null; // Just do nothing!

            var messageContent = result?.Choices
                ?.FirstOrDefault()
                ?.Message
                ?.Content;

            return messageContent
                ?.Replace("\r", string.Empty)
                ?.ReplaceLineEndings(Environment.NewLine)
                ?? string.Empty;
        }
        catch (JsonException ex)
        {
            throw new NotSupportedException($"Failed to parse the response from OpenAI API. OpenAI Response: '{body}'", ex);
        }
        catch (Exception ex)
        {
            throw new NotSupportedException($"Exception occured while processing using OpenAI API. OpenAI Response: '{body}'", ex);
        }
    }

    public class ResponseModel
    {
        public List<Choice>? Choices { get; set; }
    }
    
    public class Choice
    {
        public Message? Message { get; set; }
    }

    public class Message
    {
        public string? Content { get; set; }
    }
}
