// This code was generated in whole or in part by GenAI tool

namespace MultiAgentWinFormsApp.Forms;

public class AddAgentDialog : Form
{
    private TextBox txtName;
    private TextBox txtPrompt;
    private Button btnOk;
    private Button btnCancel;

    public string AgentName => txtName.Text;
    public string AgentPrompt => txtPrompt.Text;

    public AddAgentDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        txtName = new TextBox { PlaceholderText = "Agent Name", Width = 300 };
        txtPrompt = new TextBox { PlaceholderText = "Agent Prompt", Width = 300, Multiline = true, Height = 100 };
        btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

        var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        layout.Controls.Add(new Label { Text = "Name:" });
        layout.Controls.Add(txtName);
        layout.Controls.Add(new Label { Text = "Prompt:" });
        layout.Controls.Add(txtPrompt);
        layout.Controls.Add(btnOk);
        layout.Controls.Add(btnCancel);

        Controls.Add(layout);
        Text = "Add Agent";
        AcceptButton = btnOk;
        CancelButton = btnCancel;
    }
}
