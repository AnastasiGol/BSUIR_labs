using System.ComponentModel;

namespace Flowershop;

partial class ShowPropertiesForm
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
        infoLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(24, 41);
        label1.Name = "label1";
        label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        label1.Size = new System.Drawing.Size(242, 38);
        label1.TabIndex = 1;
        label1.Text = "Flower Info:";
        label1.Visible = false;
        label1.Click += label1_Click_1;
        // 
        // infoLabel
        // 
        infoLabel.Location = new System.Drawing.Point(24, 103);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new System.Drawing.Size(522, 119);
        infoLabel.TabIndex = 2;
        infoLabel.Text = "label2";
        // 
        // ShowPropertiesForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(877, 644);
        Controls.Add(infoLabel);
        Controls.Add(label1);
        Location = new System.Drawing.Point(22, 22);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label infoLabel;

    private System.Windows.Forms.Label label1;

    #endregion
}