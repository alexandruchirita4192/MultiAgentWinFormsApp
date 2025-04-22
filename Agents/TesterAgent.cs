// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public class TesterAgent : BaseAgent
{
    public override string Name => "Tester Agent";
    public override string Prompt => base.Prompt + "Check code branches for missing corner cases, missing exception handling or missing default values:";
    public TesterAgent(ILLMService llmService) : base(llmService) { }
}
