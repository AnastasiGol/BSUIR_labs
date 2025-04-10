using System.ComponentModel;

namespace Lab1;

partial class EditFlowerForm
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
        nameLabel = new System.Windows.Forms.Label();
        saveButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // nameLabel
        // 
        nameLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        nameLabel.Location = new System.Drawing.Point(12, 38);
        nameLabel.Name = "nameLabel";
        nameLabel.Size = new System.Drawing.Size(187, 47);
        nameLabel.TabIndex = 0;
        nameLabel.Text = "Name";
        nameLabel.Click += label1_Click;
        // 
        // saveButton
        // 
        saveButton.Location = new System.Drawing.Point(595, 504);
        saveButton.Name = "saveButton";
        saveButton.Size = new System.Drawing.Size(217, 70);
        saveButton.TabIndex = 1;
        saveButton.Text = "Сохранить";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // EditFlowerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(869, 602);
        Controls.Add(saveButton);
        Controls.Add(nameLabel);
        Text = "EditFlowerForm";
        Load += EditFlowerForm_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button saveButton;

    private System.Windows.Forms.Label nameLabel;

    #endregion
}