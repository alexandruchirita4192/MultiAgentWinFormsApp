// This code was generated in whole or in part by GenAI tool

using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

public class UnitTestAgent : BaseAgent
{
    public override string Name => "Unit Test Agent";
    public override string Prompt => base.Prompt + "Generate NUnit unit tests for this code in an appended class:";
    public UnitTestAgent(ILLMService llmService) : base(llmService) { }
}
