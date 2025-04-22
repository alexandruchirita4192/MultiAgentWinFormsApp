// This code was generated in whole or in part by GenAI tool
using System.Configuration;

namespace MultiAgentWinFormsApp;

public static class EnvironmentContext
{
    private static readonly string? _mode;
    private static readonly string? _backend;
    private static readonly string? _openAIKey;
    private static readonly string? _openAIModel;
    private static readonly string? _gitHubToken;

    public static class OrchestratorMode
    {
        public static bool IsSinglePass => _mode?.Equals(Constants.OrchestrationMode.SinglePass, StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static bool IsLoop => _mode?.Equals(Constants.OrchestrationMode.Loop, StringComparison.OrdinalIgnoreCase)
            ?? false;
    }

    public static class BackEnd
    {
        public static bool IsOpenAi => _backend?.Equals(nameof(Constants.LLMBackend.OpenAI), StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static bool IsCopilot => _backend?.Equals(nameof(Constants.LLMBackend.Copilot), StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static string OpenAIKey => string.IsNullOrEmpty(_openAIKey)
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.OpenAI.OpenAIKey}' is not set.")
            : _openAIKey;

        public static string OpenAIModel => string.IsNullOrEmpty(_openAIModel)
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.OpenAI.OpenAIModel}' is not set.")
            : _openAIModel;

        public static string GitHubToken => string.IsNullOrEmpty(_gitHubToken)
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.Copilot.GitHubToken}' is not set.")
            : _gitHubToken;
    }

    public static class BaseAgent
    {
        public static string Prompt => OrchestratorMode.IsLoop
            ? ConfigurationManager.AppSettings["LoopPrompt"]
            : (OrchestratorMode.IsSinglePass
                ? ConfigurationManager.AppSettings["SinglePassPrompt"]
                : throw new InvalidOperationException("Invalid orchestration mode."));

        public static string MainFormat = ConfigurationManager.AppSettings["MainFormat"];
    }

    static EnvironmentContext()
    {
        _mode = ConfigurationManager.AppSettings[nameof(Constants.OrchestrationMode)];
        _backend = ConfigurationManager.AppSettings[nameof(Constants.LLMBackend)];
        _openAIKey = ConfigurationManager.AppSettings[Constants.LLMBackend.OpenAI.OpenAIKey];
        _openAIModel = ConfigurationManager.AppSettings[Constants.LLMBackend.OpenAI.OpenAIModel];
        _gitHubToken = ConfigurationManager.AppSettings[Constants.LLMBackend.Copilot.GitHubToken];
    }
}
