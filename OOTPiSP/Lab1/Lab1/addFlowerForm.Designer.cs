using System.ComponentModel;

namespace Lab1;

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
        comboBox1 = new System.Windows.Forms.ComboBox();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
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
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(225, 93);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(170, 33);
        comboBox1.TabIndex = 2;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(12, 215);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(122, 28);
        label3.TabIndex = 3;
        label3.Text = "Describe it:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(34, 280);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(100, 23);
        label4.TabIndex = 4;
        label4.Text = "label4";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(34, 335);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(100, 23);
        label5.TabIndex = 5;
        label5.Text = "label5";
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(225, 280);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(170, 31);
        textBox1.TabIndex = 6;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(225, 332);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(170, 31);
        textBox2.TabIndex = 7;
        // 
        // addFlowerForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(comboBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Text = "addFlowerForm";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    #endregion
}