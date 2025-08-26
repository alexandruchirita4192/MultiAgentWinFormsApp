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

    public MainForm()
    {
        InitializeComponent();

        _llmService = LlmServiceFactory.Create(new HttpClient());
        _orchestrator = new OrchestratorClient(_llmService);

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

        // Register agents with shared LLM service
        var configurableAgentsList = ConfigurableAgent.LoadAgentsFromConfig(_llmService);
        foreach (var configurableAgent in configurableAgentsList)
            _orchestrator.RegisterAgent(configurableAgent);
    }

    private void BtnAddAgent_Click(object sender, EventArgs e)
    {
        using (var dialog = new AddAgentDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var name = dialog.AgentName;
                var prompt = dialog.AgentPrompt;

                // Add to configuration
                Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
                    .AddAndSave(name, prompt);

                // Refresh list
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

            // Remove from configuration
            Constants.AppSettings.AgentConfigurations.GetConfigurationSection()
                .RemoveAndSave(name);

            // Refresh list
            LoadAgentsFromConfig();
        }
    }
}
