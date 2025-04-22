// This code was generated in whole or in part by GenAI tool
namespace MultiAgentWinFormsApp;

public static class Constants
{
    public static class OrchestrationMode
    {
        public const string Loop = "Loop";
        public const string SinglePass = "SinglePass";
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
