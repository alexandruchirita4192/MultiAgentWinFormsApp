// This code was generated in whole or in part by GenAI tool
using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public abstract class BaseAgent : IAgent
{
    public abstract string Name { get; }
    public virtual string Prompt => EnvironmentContext.BaseAgent.Prompt;

    private readonly ILLMService _llm;
    public BaseAgent(ILLMService llmService) => _llm = llmService;

    public async Task<string> AnalyzeAsync(string fileName, string content)
        => await _llm.GenerateAsync(
            // Default MainFormat is: $"{Prompt}{Environment.NewLine}File `{fileName}`:{Environment.NewLine}```{content}```"
            string.Format(EnvironmentContext.BaseAgent.MainFormat,
                Prompt,
                "File",
                fileName,
                content,
                Environment.NewLine));
}
