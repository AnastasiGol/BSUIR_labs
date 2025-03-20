using System.ComponentModel;

namespace Lab1;

partial class ShowFlowersForm
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
        label1 = new System.Windows.Forms.Label();
        listBox1 = new System.Windows.Forms.ListBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(12, 44);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(181, 40);
        label1.TabIndex = 0;
        label1.Text = "Ваши цветы:";
        label1.Click += label1_Click;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 25;
        listBox1.Location = new System.Drawing.Point(12, 108);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(1033, 629);
        listBox1.TabIndex = 1;
        listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // ShowFlowersForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1057, 765);
        Controls.Add(listBox1);
        Controls.Add(label1);
        Text = "ShowFlowersForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}