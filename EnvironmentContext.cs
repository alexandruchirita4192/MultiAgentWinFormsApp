// This code was generated in whole or in part by GenAI tool
using System.Configuration;
using MultiAgentWinFormsApp.Extensions;

namespace MultiAgentWinFormsApp;

public static class EnvironmentContext
{
    public static class OrchestratorMode
    {
        private static readonly string? _mode;

        static OrchestratorMode()
        {
            _mode = ConfigurationManager.AppSettings[nameof(Constants.OrchestrationMode)];
        }

        public static bool IsSinglePass => _mode?.Equals(Constants.OrchestrationMode.SinglePass, StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static bool IsLoop => _mode?.Equals(Constants.OrchestrationMode.Loop, StringComparison.OrdinalIgnoreCase)
            ?? false;
    }

    public static class BackEnd
    {
        private static readonly string? _backend;
        private static readonly string? _openAIKey;
        private static readonly string? _openAIModel;
        private static readonly string? _gitHubToken;

        static BackEnd()
        {
            _backend = ConfigurationManager.AppSettings[nameof(Constants.LLMBackend)];
            _openAIKey = ConfigurationManager.AppSettings[Constants.LLMBackend.OpenAI.OpenAIKey];
            _openAIModel = ConfigurationManager.AppSettings[Constants.LLMBackend.OpenAI.OpenAIModel];
            _gitHubToken = ConfigurationManager.AppSettings[Constants.LLMBackend.Copilot.GitHubToken];
        }

        public static bool IsOpenAi => _backend?.Equals(nameof(Constants.LLMBackend.OpenAI), StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static bool IsCopilot => _backend?.Equals(nameof(Constants.LLMBackend.Copilot), StringComparison.OrdinalIgnoreCase)
            ?? false;

        public static string OpenAIKey => _openAIKey.IsEmpty()
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.OpenAI.OpenAIKey}' is not set.")
            : _openAIKey;

        public static string OpenAIModel => _openAIModel.IsEmpty()
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.OpenAI.OpenAIModel}' is not set.")
            : _openAIModel;

        public static string GitHubToken => _gitHubToken.IsEmpty()
            ? throw new InvalidOperationException($"'{Constants.LLMBackend.Copilot.GitHubToken}' is not set.")
            : _gitHubToken;
    }

    public static class BaseAgent
    {
        public static string LoopPrompt => ConfigurationManager.AppSettings[Constants.BaseAgent.LoopPrompt]
            ?? throw new InvalidOperationException($"'{Constants.BaseAgent.LoopPrompt}' is not set.");

        public static string SinglePassPrompt => ConfigurationManager.AppSettings[Constants.BaseAgent.SinglePassPrompt]
            ?? throw new InvalidOperationException($"'{Constants.BaseAgent.SinglePassPrompt}' is not set.");

        public static string Prompt => OrchestratorMode.IsLoop
            ? LoopPrompt
            : (OrchestratorMode.IsSinglePass
                ? SinglePassPrompt
                : throw new InvalidOperationException("Invalid orchestration mode."));

        public static string MainFormat => ConfigurationManager.AppSettings[Constants.BaseAgent.MainFormat]
            ?? throw new InvalidOperationException($"'{Constants.BaseAgent.MainFormat}' is not set.");
    }
}
