// This code was generated in whole or in part by GenAI tool

using NUnit.Framework;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MultiAgentWinFormsApp.Services;
using System;

namespace MultiAgentWinFormsApp.Test;

[TestFixture]
public class OpenAiLlmServiceTests
{
    private Mock<HttpMessageHandler> _mockHandler;
    private string _apiKey;

    [SetUp]
    public void Setup()
    {
        _mockHandler = new Mock<HttpMessageHandler>();
        _apiKey = "testApiKey";
    }

    [Test]
    public async Task GenerateAsync_ReturnsExpectedString()
    {
        // Arrange
        var expected = "Expected output";
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(
                "{\"id\": \"chatcmpl-5b6a367b1b814f9db03f44b0ecc39645\", " +
                "\"object\": \"chat.completion\", " +
                "\"created\": 1626470196, " +
                "\"model\": \"text-davinci-002\", " +
                "\"usage\": {\"prompt_tokens\": 23, \"completion_tokens\": 31, \"total_tokens\": 54}, " +
                $"\"choices\": [{{\"message\": {{\"role\": \"assistant\", \"content\": \"{expected}\"}}}}]}}"
            )
        };
        _mockHandler.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);
            var client = new HttpClient(_mockHandler.Object)
            {
                BaseAddress = new Uri("https://api.openai.com/")
            };
            var service = new OpenAiLlmService(_apiKey, client);

            // Act
            var result = await service.GenerateAsync("Prompt");

            // Assert
            Assert.AreEqual(expected, result);
        }
}