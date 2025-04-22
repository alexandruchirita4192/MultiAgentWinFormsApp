// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public class PrincipleReviewerAgent : BaseAgent
{
    public override string Name => "Principle Reviewer Agent";
    public override string Prompt => base.Prompt + "Please review the following C# code for simplicity, readability, and SOLID/OOP/OOD adherence:";
    public PrincipleReviewerAgent(ILLMService llmService) : base(llmService) { }
}
