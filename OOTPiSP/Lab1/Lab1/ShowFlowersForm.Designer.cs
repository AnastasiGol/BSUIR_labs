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
        flowersBox = new System.Windows.Forms.ListBox();
        addNewButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
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
        // flowersBox
        // 
        flowersBox.FormattingEnabled = true;
        flowersBox.ItemHeight = 25;
        flowersBox.Location = new System.Drawing.Point(12, 108);
        flowersBox.Name = "flowersBox";
        flowersBox.Size = new System.Drawing.Size(1033, 604);
        flowersBox.TabIndex = 1;
        flowersBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // addNewButton
        // 
        addNewButton.Location = new System.Drawing.Point(72, 733);
        addNewButton.Name = "addNewButton";
        addNewButton.Size = new System.Drawing.Size(242, 74);
        addNewButton.TabIndex = 2;
        addNewButton.Text = "Добавить новый";
        addNewButton.UseVisualStyleBackColor = true;
        addNewButton.Click += addNewButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Location = new System.Drawing.Point(359, 733);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(242, 74);
        deleteButton.TabIndex = 3;
        deleteButton.Text = "Удалить";
        deleteButton.UseVisualStyleBackColor = true;
        // 
        // ShowFlowersForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1062, 819);
        Controls.Add(deleteButton);
        Controls.Add(addNewButton);
        Controls.Add(flowersBox);
        Controls.Add(label1);
        Text = "Мои цветы";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button addNewButton;
    private System.Windows.Forms.Button deleteButton;

    private System.Windows.Forms.ListBox flowersBox;

    private System.Windows.Forms.Label label1;

    #endregion
}