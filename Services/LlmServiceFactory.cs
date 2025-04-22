// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;
using static MultiAgentWinFormsApp.EnvironmentContext;

namespace MultiAgentWinFormsApp.Services;

public static class LlmServiceFactory
{
    public static ILLMService Create(HttpClient httpClient)
    {
        if (BackEnd.IsOpenAi)
            return new OpenAiLlmService(httpClient);
        else if (BackEnd.IsCopilot)
            return new CopilotLlmService(BackEnd.GitHubToken);
        else
            throw new NotSupportedException("Unsupported LLM backend specified in app settings. Supported back-ends are: 'Copilot' and 'OpenAI'!");
    }
}
