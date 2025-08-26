// This code was generated in whole or in part by GenAI tool

using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace MultiAgentWinFormsApp.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty([NotNullWhen(false)] this string? s) => string.IsNullOrEmpty(s);

    public static bool IsNotEmpty([NotNullWhen(true)] this string? s) => !s.IsEmpty();

    public static Section GetConfigurationSection(this string sectionName)
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
        var configurationSection = config.GetSection(sectionName);
        if (configurationSection == null)
            throw new InvalidOperationException($"'{sectionName}' is not set in app settings.");
        
        return new Section(configurationSection);
    }
}
