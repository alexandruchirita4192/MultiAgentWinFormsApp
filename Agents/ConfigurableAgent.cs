// This code was generated in whole or in part by GenAI tool

using System.Configuration;
using System.Xml.Linq;
using MultiAgentWinFormsApp.Interfaces;

namespace MultiAgentWinFormsApp.Agents;

/// <summary>
/// A configurable agent that initializes its properties based on App.config settings.
/// </summary>
public class ConfigurableAgent : BaseAgent
{
    public override string Name { get; }
    public override string Prompt { get; }

    public ConfigurableAgent(string name, string prompt, ILLMService llmService)
        : base(llmService)
    {
        Name = name;
        Prompt = prompt;
    }

    /// <summary>
    /// Reads agent configurations from App.config and creates a list of ConfigurableAgent instances.
    /// </summary>
    public static List<ConfigurableAgent> LoadAgentsFromConfig(ILLMService llmService)
    {
        var agents = new List<ConfigurableAgent>();
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var agentSection = config.GetSection("agentConfigurations") as DefaultSection;

        if (agentSection != null)
        {
            var agentElements = XElement.Parse(agentSection.SectionInformation.GetRawXml()).Elements("add");
            foreach (var element in agentElements)
            {
                var name = element.Attribute("key")?.Value;
                var prompt = element.Attribute("value")?.Value;

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(prompt))
                {
                    agents.Add(new ConfigurableAgent(name, prompt, llmService));
                }
            }
        }

        return agents;
    }
}
