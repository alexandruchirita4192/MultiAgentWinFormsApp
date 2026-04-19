// This code was generated in whole or in part by GenAI tool
using MultiAgentWinFormsApp.Extensions;

namespace MultiAgentWinFormsApp;

public static class AgentPresetParser
{
    private const string AgentDelimiter = "||";
    private const string KeyValueDelimiter = "::";

    public static Dictionary<string, List<KeyValuePair<string, string>>> ParsePresets(string sectionName)
    {
        var sectionElements = sectionName.GetConfigurationSection().GetSectionElements();
        var result = new Dictionary<string, List<KeyValuePair<string, string>>>(StringComparer.OrdinalIgnoreCase);

        foreach (var element in sectionElements.Elements("add"))
        {
            var presetName = element.Attribute("key")?.Value;
            var serializedAgents = element.Attribute("value")?.Value;

            if (presetName.IsEmpty() || serializedAgents.IsEmpty())
                continue;

            var agents = ParseAgents(serializedAgents);
            if (agents.Count > 0)
                result[presetName] = agents;
        }

        return result;
    }

    private static List<KeyValuePair<string, string>> ParseAgents(string serializedAgents)
    {
        var agents = new List<KeyValuePair<string, string>>();

        foreach (var rawEntry in serializedAgents.Split(AgentDelimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var parts = rawEntry.Split(KeyValueDelimiter, 2, StringSplitOptions.TrimEntries);
            if (parts.Length != 2)
                continue;

            var name = parts[0];
            var prompt = parts[1];
            if (name.IsEmpty() || prompt.IsEmpty())
                continue;

            agents.Add(new KeyValuePair<string, string>(name, prompt));
        }

        return agents;
    }
}
