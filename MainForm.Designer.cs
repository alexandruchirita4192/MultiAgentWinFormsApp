// This code was generated in whole or in part by GenAI tool
namespace MultiAgentWinFormsApp;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtFilePath;
    private System.Windows.Forms.TextBox txtOutput;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.txtFilePath = new System.Windows.Forms.TextBox();
        this.txtOutput = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // txtFilePath
        // 
        this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtFilePath.Location = new System.Drawing.Point(12, 12);
        this.txtFilePath.Name = "txtFilePath";
        this.txtFilePath.ReadOnly = true;
        this.txtFilePath.Size = new System.Drawing.Size(560, 23);
        this.txtFilePath.TabIndex = 0;
        // 
        // txtOutput
        // 
        this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtOutput.Location = new System.Drawing.Point(12, 41);
        this.txtOutput.Multiline = true;
        this.txtOutput.Name = "txtOutput";
        this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txtOutput.Size = new System.Drawing.Size(560, 307);
        this.txtOutput.TabIndex = 1;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(584, 360);
        this.Controls.Add(this.txtOutput);
        this.Controls.Add(this.txtFilePath);
        this.Name = "MainForm";
        this.Text = "Multi-Agent Code Reviewer";
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
