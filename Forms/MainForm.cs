// This code was generated in whole or in part by GenAI tool
using System.Configuration;
using MultiAgentWinFormsApp.Agents;
using MultiAgentWinFormsApp.Extensions;
using MultiAgentWinFormsApp.Interfaces;
using MultiAgentWinFormsApp.Services;

namespace MultiAgentWinFormsApp.Forms;

public partial class MainForm : Form
{
    private readonly ILLMService _llmService;
    private readonly OrchestratorClient _orchestrator;
    private readonly Dictionary<string, List<KeyValuePair<string, string>>> _agentPresets = new(StringComparer.OrdinalIgnoreCase);

    public MainForm()
    {
        InitializeComponent();

        _llmService = LlmServiceFactory.Create(new HttpClient());
        _orchestrator = new OrchestratorClient();

        LoadAgentPresets();
        LoadAgentsFromConfig();

        AllowDrop = true;
        DragEnter += MainForm_DragEnter;
        DragDrop += MainForm_DragDrop;
    }

    private void MainForm_DragEnter(object? sender, DragEventArgs e)
    {
        e.Effect = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false
            ? DragDropEffects.Copy
            : DragDropEffects.None;
    }

    private async void MainForm_DragDrop(object? sender, DragEventArgs e)
    {
        var files = e.Data?.GetData(DataFormats.FileDrop) as string[];
        if (files == null || files.Length == 0)
            return;

        var fileName = files[0];
        if (fileName == null)
            return;

        txtFilePath.Text = fileName;
        var content = File.ReadAllText(fileName);
        txtOutput.Text = "Processing...";

        var results = await _orchestrator.RunAsync(fileName, content);
        txtOutput.Text = string.Join("\r\n---\r\n", results);
    }

    private void LoadAgentPresets()
    {
        _agentPresets.Clear();
        cmbAgentPreset.Items.Clear();

        var presets = AgentPresetParser.ParsePresets(Constants.AppSettings.AgentPresetConfigurations);
        foreach (var preset in presets)
        {
            _agentPresets[preset.Key] = preset.Value;
            cmbAgentPreset.Items.Add(preset.Key);
        }

        if (cmbAgentPreset.Items.Count > 0)
            cmbAgentPreset.SelectedIndex = 0;
    }

    private void LoadAgentsFromConfig()
    {
        lvAgents.Items.Clear();

        var elements = Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
            .GetSectionElements()
            .Elements("add");

        foreach (var element in elements)
        {
            var name = element.Attribute("key")?.Value;
            var prompt = element.Attribute("value")?.Value;

            if (name.IsNotEmpty() && prompt.IsNotEmpty())
            {
                var item = new ListViewItem(new[] { name, prompt });
                lvAgents.Items.Add(item);
            }
        }

        var configurableAgentsList = ConfigurableAgent.LoadAgentsFromConfig(_llmService);
        _orchestrator.SetAgents(configurableAgentsList);
    }

    private void BtnAddAgent_Click(object sender, EventArgs e)
    {
        using (var dialog = new AddAgentDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var name = dialog.AgentName;
                var prompt = dialog.AgentPrompt;

                Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
                    .AddAndSave(name, prompt);

                LoadAgentsFromConfig();
            }
        }
    }

    private void BtnRemoveAgent_Click(object sender, EventArgs e)
    {
        if (lvAgents.SelectedItems.Count > 0)
        {
            var selectedItem = lvAgents.SelectedItems[0];
            var name = selectedItem.SubItems[0].Text;

            Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
                .RemoveAndSave(name);

            LoadAgentsFromConfig();
        }
    }

    private void BtnApplyPreset_Click(object sender, EventArgs e)
    {
        var presetName = cmbAgentPreset.SelectedItem?.ToString();
        if (presetName.IsEmpty())
            return;

        if (!_agentPresets.TryGetValue(presetName!, out var presetAgents) || presetAgents.Count == 0)
            return;

        Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
            .ReplaceAllAndSave(presetAgents);

        LoadAgentsFromConfig();
        txtOutput.Text = $"Applied preset: {presetName}";
    }
}
