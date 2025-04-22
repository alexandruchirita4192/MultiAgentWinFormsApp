// This code was generated in whole or in part by GenAI tool
using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public abstract class BaseAgent : IAgent
{
    public abstract string Name { get; }
    public virtual string Prompt => EnvironmentContext.OrchestratorMode.IsLoop
        ? "Modify the following file to improve it as specified below. " +
        "If the file has no improvements that can be made based on the requirements specified below then leave it unchanged."
        : (
            EnvironmentContext.OrchestratorMode.IsSinglePass
            ? "Review the following file and add fix points as specified below."
            : throw new InvalidOperationException("Invalid orchestration mode.")
        );

    private readonly ILLMService _llm;
    public BaseAgent(ILLMService llmService) => _llm = llmService;

    public async Task<string> AnalyzeAsync(string fileName, string content)
        => await _llm.GenerateAsync(Prompt + Environment.NewLine + $"File `{fileName}`:" + Environment.NewLine + $"```{content}```");
}
