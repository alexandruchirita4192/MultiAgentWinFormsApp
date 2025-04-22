// This code was generated in whole or in part by GenAI tool
using MultiAgentWinFormsApp.Agents;
using MultiAgentWinFormsApp.Services;

namespace MultiAgentWinFormsApp;

public partial class MainForm : Form
{
    private readonly OrchestratorClient _orchestrator;

    public MainForm()
    {
        InitializeComponent();
        // Choose LLM backend
        var llmService = LlmServiceFactory.Create(new HttpClient());

        _orchestrator = new OrchestratorClient();

        // Register agents with shared LLM service
        _orchestrator.RegisterAgent(new AddNoticeAgent(llmService));
        _orchestrator.RegisterAgent(new PrincipleReviewerAgent(llmService));
        _orchestrator.RegisterAgent(new TesterAgent(llmService));
        _orchestrator.RegisterAgent(new FindBugsFixAgent(llmService));
        _orchestrator.RegisterAgent(new MultiThreadingExpertAgent(llmService));
        _orchestrator.RegisterAgent(new UnitTestAgent(llmService));

        this.AllowDrop = true;
        this.DragEnter += MainForm_DragEnter;
        this.DragDrop += MainForm_DragDrop;
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
            ? DragDropEffects.Copy
            : DragDropEffects.None;
    }

    private async void MainForm_DragDrop(object sender, DragEventArgs e)
    {
        var files = (string[])e.Data.GetData(DataFormats.FileDrop);
        if ((files?.Length ?? 0) == 0)
            return;

        var fileName = files[0];
        txtFilePath.Text = fileName;
        var content = File.ReadAllText(fileName);
        txtOutput.Text = "Processing...";

        var results = await _orchestrator.RunAsync(fileName, content);
        txtOutput.Text = string.Join("\r\n---\r\n", results);
    }
}
