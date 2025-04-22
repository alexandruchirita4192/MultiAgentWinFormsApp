// This code was generated in whole or in part by GenAI tool
namespace MultiAgentWinFormsApp.Interfaces;

/// <summary>
/// Interface for custom analysis agents.
/// </summary>
public interface IAgent
{
    string Name { get; }
    Task<string> AnalyzeAsync(string fileName, string content);
}
