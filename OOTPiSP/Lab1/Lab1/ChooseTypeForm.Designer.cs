using System.ComponentModel;

namespace Lab1;

partial class ChooseTypeForm
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
        formatComboBox = new System.Windows.Forms.ComboBox();
        okButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        fileTextBox = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        encryptComboBox = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // formatComboBox
        // 
        formatComboBox.FormattingEnabled = true;
        formatComboBox.Location = new System.Drawing.Point(12, 78);
        formatComboBox.Name = "formatComboBox";
        formatComboBox.Size = new System.Drawing.Size(328, 33);
        formatComboBox.TabIndex = 0;
        // 
        // okButton
        // 
        okButton.Enabled = false;
        okButton.Location = new System.Drawing.Point(12, 457);
        okButton.Name = "okButton";
        okButton.Size = new System.Drawing.Size(247, 73);
        okButton.TabIndex = 1;
        okButton.Text = "Выбрать";
        okButton.UseVisualStyleBackColor = true;
        okButton.Click += okButton_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 41);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(176, 34);
        label1.TabIndex = 2;
        label1.Text = "Choose type:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 166);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(176, 34);
        label2.TabIndex = 3;
        label2.Text = "Enter file name:";
        // 
        // fileTextBox
        // 
        fileTextBox.Location = new System.Drawing.Point(12, 203);
        fileTextBox.Name = "fileTextBox";
        fileTextBox.Size = new System.Drawing.Size(278, 31);
        fileTextBox.TabIndex = 4;
        fileTextBox.TextChanged += fileTextBox_TextChanged;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(12, 276);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(302, 34);
        label3.TabIndex = 5;
        label3.Text = "Encrypt before saving:";
        // 
        // encryptComboBox
        // 
        encryptComboBox.FormattingEnabled = true;
        encryptComboBox.Location = new System.Drawing.Point(12, 313);
        encryptComboBox.Name = "encryptComboBox";
        encryptComboBox.Size = new System.Drawing.Size(176, 33);
        encryptComboBox.TabIndex = 6;
        // 
        // ChooseTypeForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(718, 571);
        Controls.Add(encryptComboBox);
        Controls.Add(label3);
        Controls.Add(fileTextBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(okButton);
        Controls.Add(formatComboBox);
        Text = "ChooseTypeForm";
        Load += ChoosTypeForm_Load_1;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox encryptComboBox;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox fileTextBox;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button okButton;

    private System.Windows.Forms.ComboBox formatComboBox;

    #endregion
}