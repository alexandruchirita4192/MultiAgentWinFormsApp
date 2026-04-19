// This code was generated in whole or in part by GenAI tool
namespace MultiAgentWinFormsApp;

public static class Constants
{
    public static class AppSettings
    {
        public const string AgentConfigurations = "agentConfigurations";
        public const string AgentPresetConfigurations = "agentPresetConfigurations";
    }

    public static class OrchestrationMode
    {
        public const string Loop = "Loop";
        public const string SinglePass = "SinglePass";
    }

    public static class BaseAgent
    {
        public const string LoopPrompt = "LoopPrompt";
        public const string SinglePassPrompt = "SinglePassPrompt";
        public const string MainFormat = "MainFormat";
    }

    public static class LLMBackend
    {
        public static class OpenAI
        {
            public const string OpenAIKey = "OpenAIKey";

            public static string OpenAIModel = "OpenAIModel";
        }

        public static class Copilot
        {
            public const string GitHubToken = "GitHubToken";
        }
    }
}
