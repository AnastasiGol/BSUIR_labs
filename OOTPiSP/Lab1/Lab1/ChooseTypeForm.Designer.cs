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
        okButton.Location = new System.Drawing.Point(12, 351);
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
        label1.Text = "Выберете тип:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 166);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(176, 34);
        label2.TabIndex = 3;
        label2.Text = "Введите имя файла:";
        // 
        // fileTextBox
        // 
        fileTextBox.Location = new System.Drawing.Point(12, 203);
        fileTextBox.Name = "fileTextBox";
        fileTextBox.Size = new System.Drawing.Size(278, 31);
        fileTextBox.TabIndex = 4;
        fileTextBox.TextChanged += fileTextBox_TextChanged;
        // 
        // ChooseTypeForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(694, 500);
        Controls.Add(fileTextBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(okButton);
        Controls.Add(formatComboBox);
        Text = "ChooseTypeForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox fileTextBox;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button okButton;

    private System.Windows.Forms.ComboBox formatComboBox;

    #endregion
}