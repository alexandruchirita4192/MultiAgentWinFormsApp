// This code was generated in whole or in part by GenAI tool
namespace MultiAgentWinFormsApp.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtFilePath;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.ListView lvAgents;
    private System.Windows.Forms.Button btnAddAgent;
    private System.Windows.Forms.Button btnRemoveAgent;

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
        this.lvAgents = new System.Windows.Forms.ListView();
        this.btnAddAgent = new System.Windows.Forms.Button();
        this.btnRemoveAgent = new System.Windows.Forms.Button();
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
        this.txtOutput.Location = new System.Drawing.Point(12, 250);
        this.txtOutput.Multiline = true;
        this.txtOutput.Name = "txtOutput";
        this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txtOutput.Size = new System.Drawing.Size(560, 98);
        this.txtOutput.TabIndex = 1;
        // 
        // lvAgents
        // 
        this.lvAgents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.lvAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                    new System.Windows.Forms.ColumnHeader { Text = "Name", Width = 200 },
                    new System.Windows.Forms.ColumnHeader { Text = "Prompt", Width = 340 }
                });
        this.lvAgents.FullRowSelect = true;
        this.lvAgents.GridLines = true;
        this.lvAgents.Location = new System.Drawing.Point(12, 41);
        this.lvAgents.Name = "lvAgents";
        this.lvAgents.Size = new System.Drawing.Size(560, 160);
        this.lvAgents.TabIndex = 2;
        this.lvAgents.UseCompatibleStateImageBehavior = false;
        this.lvAgents.View = System.Windows.Forms.View.Details;
        // 
        // btnAddAgent
        // 
        this.btnAddAgent.Location = new System.Drawing.Point(12, 207);
        this.btnAddAgent.Name = "btnAddAgent";
        this.btnAddAgent.Size = new System.Drawing.Size(75, 23);
        this.btnAddAgent.TabIndex = 3;
        this.btnAddAgent.Text = "Add Agent";
        this.btnAddAgent.UseVisualStyleBackColor = true;
        this.btnAddAgent.Click += new System.EventHandler(this.BtnAddAgent_Click);
        // 
        // btnRemoveAgent
        // 
        this.btnRemoveAgent.Location = new System.Drawing.Point(93, 207);
        this.btnRemoveAgent.Name = "btnRemoveAgent";
        this.btnRemoveAgent.Size = new System.Drawing.Size(100, 23);
        this.btnRemoveAgent.TabIndex = 4;
        this.btnRemoveAgent.Text = "Remove Agent";
        this.btnRemoveAgent.UseVisualStyleBackColor = true;
        this.btnRemoveAgent.Click += new System.EventHandler(this.BtnRemoveAgent_Click);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(584, 360);
        this.Controls.Add(this.btnRemoveAgent);
        this.Controls.Add(this.btnAddAgent);
        this.Controls.Add(this.lvAgents);
        this.Controls.Add(this.txtOutput);
        this.Controls.Add(this.txtFilePath);
        this.Name = "MainForm";
        this.Text = "Multi-Agent Code Reviewer";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
