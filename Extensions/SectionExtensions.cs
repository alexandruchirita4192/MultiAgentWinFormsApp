// This code was generated in whole or in part by GenAI tool

using System.Collections.Generic;
using System.Configuration;
using System.Xml.Linq;

namespace MultiAgentWinFormsApp.Extensions;

public static class SectionExtensions
{
    public static string GetString(this Section section, string key)
    {
        var value = section.Settings[key]
            ?.Value;
        if (value.IsEmpty())
            throw new InvalidOperationException($"'{key}' is not set in app settings.");
        return value;
    }

    public static XElement GetSectionElements(this Section section)
        => XElement.Parse(section.SectionInformation.GetRawXml());

    public static void SaveAndReload(this Section section, XElement sectionElements)
    {
        section.SectionInformation.SetRawXml(sectionElements.ToString());
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var loadedSection = config.Sections[section.SectionInformation.Name];
        loadedSection.SectionInformation.SetRawXml(sectionElements.ToString());
        config.Save(ConfigurationSaveMode.Full);
        ConfigurationManager.RefreshSection(section.SectionInformation.SectionName);
    }

    public static void AddAndSave(this Section section, string? newKey, string? newValue)
    {
        if (section == null)
            return;

        var sectionElements = section.GetSectionElements();

        if (newKey.IsNotEmpty() && newValue.IsNotEmpty())
            sectionElements.Add(new XElement("add", new XAttribute("key", newKey), new XAttribute("value", newValue)));
        
        section.SaveAndReload(sectionElements);
    }


    public static void ReplaceAllAndSave(this Section section, IEnumerable<KeyValuePair<string, string>> entries)
    {
        if (section == null)
            return;

        var sectionElements = section.GetSectionElements();
        sectionElements.Elements("add").Remove();

        foreach (var entry in entries)
        {
            if (entry.Key.IsEmpty() || entry.Value.IsEmpty())
                continue;

            sectionElements.Add(new XElement("add",
                new XAttribute("key", entry.Key),
                new XAttribute("value", entry.Value)));
        }

        section.SaveAndReload(sectionElements);
    }
    public static void RemoveAndSave(this Section section, string? oldKey)
    {
        if (section == null)
            return;

        var sectionElements = section.GetSectionElements();

        var keyToRemove = sectionElements.Elements("add")
            .FirstOrDefault(a => a.Attribute("key")?.Value == oldKey);
        keyToRemove?.Remove();

        section.SaveAndReload(sectionElements);
    }
}
