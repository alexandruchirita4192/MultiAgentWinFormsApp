// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public class MultiThreadingExpertAgent : BaseAgent
{
    public override string Name => "Multi-threading Expert Agent";
    public override string Prompt => base.Prompt + "Analyze the following code for thread-safety and concurrency issues:";
    public MultiThreadingExpertAgent(ILLMService llmService) : base(llmService) { }
}
