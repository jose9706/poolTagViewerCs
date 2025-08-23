using System.ComponentModel;

namespace poolViewer;

sealed partial class FilterForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        richTextBox1 = new System.Windows.Forms.RichTextBox();
        enterButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // richTextBox1
        // 
        richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
        richTextBox1.Location = new System.Drawing.Point(0, 0);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new System.Drawing.Size(322, 73);
        richTextBox1.TabIndex = 0;
        richTextBox1.Text = "";
        // 
        // enterButton
        // 
        enterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        enterButton.BackColor = System.Drawing.SystemColors.ButtonFace;
        enterButton.Location = new System.Drawing.Point(0, 77);
        enterButton.Name = "enterButton";
        enterButton.Size = new System.Drawing.Size(322, 37);
        enterButton.TabIndex = 1;
        enterButton.Text = "Confirm";
        enterButton.UseVisualStyleBackColor = false;
        enterButton.Click += button1_Click;
        // 
        // FilterForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(322, 117);
        Controls.Add(enterButton);
        Controls.Add(richTextBox1);
        Text = "FilterForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button enterButton;

    private System.Windows.Forms.RichTextBox richTextBox1;

    #endregion
}