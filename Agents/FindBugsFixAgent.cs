// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public class FindBugsFixAgent : BaseAgent
{
    public override string Name => "Find Bugs & Fix Agent";
    public override string Prompt => base.Prompt + "Find and fix bugs in this C# code, improving robustness:";
    public FindBugsFixAgent(ILLMService llmService) : base(llmService) { }
}
