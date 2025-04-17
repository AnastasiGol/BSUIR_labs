using System.ComponentModel;

namespace Flowershop;

partial class addFlowerForm
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
        label2 = new System.Windows.Forms.Label();
        flowersComboBox = new System.Windows.Forms.ComboBox();
        label3 = new System.Windows.Forms.Label();
        addButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(12, 24);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(315, 47);
        label1.TabIndex = 0;
        label1.Text = "Add new flower:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 96);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(166, 36);
        label2.TabIndex = 1;
        label2.Text = "Choose type:";
        // 
        // flowersComboBox
        // 
        flowersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        flowersComboBox.FormattingEnabled = true;
        flowersComboBox.Location = new System.Drawing.Point(225, 93);
        flowersComboBox.Name = "flowersComboBox";
        flowersComboBox.Size = new System.Drawing.Size(170, 33);
        flowersComboBox.TabIndex = 2;
        flowersComboBox.SelectedIndexChanged += flowersComboBox_SelectedIndexChanged;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label3.Location = new System.Drawing.Point(12, 215);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(122, 28);
        label3.TabIndex = 3;
        label3.Text = "Describe it:";
        // 
        // addButton
        // 
        addButton.Location = new System.Drawing.Point(678, 56);
        addButton.Name = "addButton";
        addButton.Size = new System.Drawing.Size(192, 70);
        addButton.TabIndex = 8;
        addButton.Text = "Add";
        addButton.UseVisualStyleBackColor = true;
        addButton.Visible = false;
        addButton.Click += addButton_Click;
        // 
        // addFlowerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(948, 744);
        Controls.Add(addButton);
        Controls.Add(label3);
        Controls.Add(flowersComboBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "addFlowerForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button addButton;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.ComboBox flowersComboBox;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}