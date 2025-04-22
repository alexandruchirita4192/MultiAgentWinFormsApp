// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp;

/// <summary>
/// Orchestrator that supports single-pass analysis or iterative modifications.
/// </summary>
public class OrchestratorClient
{
    private readonly List<IAgent> _agents = new();

    public OrchestratorClient()
    {
    }

    public void RegisterAgent(IAgent agent) => _agents.Add(agent);

    public async Task<List<string>> RunAsync(string fileName, string content)
    {
        if (EnvironmentContext.OrchestratorMode.IsLoop)
            return [await RunLoopAsync(fileName, content)];
        else  if (EnvironmentContext.OrchestratorMode.IsSinglePass)
            return await RunSinglePassAsync(fileName, content);
        else
            throw new InvalidOperationException("Invalid orchestration mode.");
    }

    private async Task<List<string>> RunSinglePassAsync(string fileName, string content)
    {
        var results = new List<string>();
        foreach (var agent in _agents)
        {
            var analysis = await agent.AnalyzeAsync(fileName, content);
            results.Add($"[{agent.Name}] Analysis:\n{analysis}");
        }
        return results;
    }

    private async Task<string> RunLoopAsync(string fileName, string initial)
    {
        string current = initial;
        bool changed;

        do
        {
            changed = false;
            foreach (var agent in _agents)
            {
                var updated = await agent.AnalyzeAsync(fileName, current);
                if (updated != current)
                {
                    current = updated;
                    changed = true;
                }
            }
        }
        while (changed);

        return current;
    }
}
