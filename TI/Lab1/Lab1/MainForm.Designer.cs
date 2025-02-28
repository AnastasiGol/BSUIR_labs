using System.ComponentModel;

namespace Lab1;

partial class MainForm
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
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        plainTextBox = new System.Windows.Forms.TextBox();
        keyTextbox = new System.Windows.Forms.TextBox();
        resultTextBox = new System.Windows.Forms.TextBox();
        decimationButton = new System.Windows.Forms.RadioButton();
        vizhinerButton = new System.Windows.Forms.RadioButton();
        decipherButton = new System.Windows.Forms.RadioButton();
        encypherButton = new System.Windows.Forms.RadioButton();
        executeBtn = new System.Windows.Forms.Button();
        cipherGroupBox = new System.Windows.Forms.GroupBox();
        algorithmGroupBox = new System.Windows.Forms.GroupBox();
        toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        fileBtn = new System.Windows.Forms.Button();
        openFileDialog = new System.Windows.Forms.OpenFileDialog();
        writeFileBtn = new System.Windows.Forms.Button();
        saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        cipherGroupBox.SuspendLayout();
        algorithmGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(493, 40);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(186, 30);
        label2.TabIndex = 1;
        label2.Text = "Исходный текст";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(493, 241);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(186, 30);
        label3.TabIndex = 2;
        label3.Text = "Ключ";
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label4.Location = new System.Drawing.Point(493, 393);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(186, 30);
        label4.TabIndex = 3;
        label4.Text = "Результат";
        // 
        // plainTextBox
        // 
        plainTextBox.Location = new System.Drawing.Point(493, 73);
        plainTextBox.Multiline = true;
        plainTextBox.Name = "plainTextBox";
        plainTextBox.Size = new System.Drawing.Size(344, 154);
        plainTextBox.TabIndex = 4;
        plainTextBox.TextChanged += plainTextBoxChanged;
        // 
        // keyTextbox
        // 
        keyTextbox.Location = new System.Drawing.Point(493, 274);
        keyTextbox.Multiline = true;
        keyTextbox.Name = "keyTextbox";
        keyTextbox.Size = new System.Drawing.Size(344, 102);
        keyTextbox.TabIndex = 5;
        keyTextbox.TextChanged += keyTextboxChanged;
        // 
        // resultTextBox
        // 
        resultTextBox.Location = new System.Drawing.Point(493, 426);
        resultTextBox.Multiline = true;
        resultTextBox.Name = "resultTextBox";
        resultTextBox.ReadOnly = true;
        resultTextBox.Size = new System.Drawing.Size(344, 173);
        resultTextBox.TabIndex = 6;
        // 
        // decimationButton
        // 
        decimationButton.Location = new System.Drawing.Point(0, 30);
        decimationButton.Name = "decimationButton";
        decimationButton.Size = new System.Drawing.Size(236, 42);
        decimationButton.TabIndex = 7;
        decimationButton.TabStop = true;
        decimationButton.Text = "Метод децимаций";
        decimationButton.UseVisualStyleBackColor = true;
        // 
        // vizhinerButton
        // 
        vizhinerButton.Location = new System.Drawing.Point(0, 78);
        vizhinerButton.Name = "vizhinerButton";
        vizhinerButton.Size = new System.Drawing.Size(236, 42);
        vizhinerButton.TabIndex = 8;
        vizhinerButton.TabStop = true;
        vizhinerButton.Text = "Шифр Вижинера";
        vizhinerButton.UseVisualStyleBackColor = true;
        // 
        // decipherButton
        // 
        decipherButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        decipherButton.Location = new System.Drawing.Point(0, 75);
        decipherButton.Name = "decipherButton";
        decipherButton.Size = new System.Drawing.Size(236, 42);
        decipherButton.TabIndex = 10;
        decipherButton.TabStop = true;
        decipherButton.Text = "Decipher";
        decipherButton.UseVisualStyleBackColor = true;
        // 
        // encypherButton
        // 
        encypherButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        encypherButton.Location = new System.Drawing.Point(0, 30);
        encypherButton.Name = "encypherButton";
        encypherButton.Size = new System.Drawing.Size(236, 42);
        encypherButton.TabIndex = 9;
        encypherButton.TabStop = true;
        encypherButton.Text = "Encypher";
        encypherButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        encypherButton.UseVisualStyleBackColor = true;
        // 
        // executeBtn
        // 
        executeBtn.Enabled = false;
        executeBtn.Location = new System.Drawing.Point(34, 393);
        executeBtn.Name = "executeBtn";
        executeBtn.Size = new System.Drawing.Size(208, 67);
        executeBtn.TabIndex = 11;
        executeBtn.Text = "Выполнить";
        executeBtn.UseVisualStyleBackColor = true;
        executeBtn.Click += executeBtn_Click;
        // 
        // cipherGroupBox
        // 
        cipherGroupBox.Controls.Add(encypherButton);
        cipherGroupBox.Controls.Add(decipherButton);
        cipherGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cipherGroupBox.Location = new System.Drawing.Point(34, 49);
        cipherGroupBox.Name = "cipherGroupBox";
        cipherGroupBox.Size = new System.Drawing.Size(248, 123);
        cipherGroupBox.TabIndex = 12;
        cipherGroupBox.TabStop = false;
        // 
        // algorithmGroupBox
        // 
        algorithmGroupBox.Controls.Add(decimationButton);
        algorithmGroupBox.Controls.Add(vizhinerButton);
        algorithmGroupBox.Location = new System.Drawing.Point(34, 241);
        algorithmGroupBox.Name = "algorithmGroupBox";
        algorithmGroupBox.Size = new System.Drawing.Size(266, 141);
        algorithmGroupBox.TabIndex = 13;
        algorithmGroupBox.TabStop = false;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.AccessibleName = "toolStripMenuItem1";
        toolStripMenuItem1.DoubleClickEnabled = true;
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.AccessibleName = "toolStripMenuItem2";
        toolStripMenuItem2.DoubleClickEnabled = true;
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.AccessibleName = "toolStripMenuItem3";
        toolStripMenuItem3.DoubleClickEnabled = true;
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.AccessibleName = "toolStripMenuItem4";
        toolStripMenuItem4.DoubleClickEnabled = true;
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
        // 
        // fileBtn
        // 
        fileBtn.Location = new System.Drawing.Point(493, 605);
        fileBtn.Name = "fileBtn";
        fileBtn.Size = new System.Drawing.Size(160, 67);
        fileBtn.TabIndex = 14;
        fileBtn.Text = "Загрузить из файла";
        fileBtn.UseVisualStyleBackColor = true;
        fileBtn.Click += fileBtn_Click;
        // 
        // writeFileBtn
        // 
        writeFileBtn.Location = new System.Drawing.Point(698, 605);
        writeFileBtn.Name = "writeFileBtn";
        writeFileBtn.Size = new System.Drawing.Size(139, 67);
        writeFileBtn.TabIndex = 15;
        writeFileBtn.Text = "Записать в файл";
        writeFileBtn.UseVisualStyleBackColor = true;
        writeFileBtn.Visible = false;
        writeFileBtn.Click += writeFileBtn_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(981, 711);
        Controls.Add(writeFileBtn);
        Controls.Add(fileBtn);
        Controls.Add(algorithmGroupBox);
        Controls.Add(cipherGroupBox);
        Controls.Add(executeBtn);
        Controls.Add(resultTextBox);
        Controls.Add(keyTextbox);
        Controls.Add(plainTextBox);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Location = new System.Drawing.Point(22, 22);
        MaximumSize = new System.Drawing.Size(1003, 767);
        MinimumSize = new System.Drawing.Size(1003, 767);
        Text = "Lab1";
        Load += MainForm_Load;
        cipherGroupBox.ResumeLayout(false);
        algorithmGroupBox.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.SaveFileDialog saveFileDialog;

    private System.Windows.Forms.Button writeFileBtn;

    private System.Windows.Forms.OpenFileDialog openFileDialog;

    private System.Windows.Forms.Button fileBtn;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    private System.Windows.Forms.GroupBox cipherGroupBox;

    private System.Windows.Forms.GroupBox algorithmGroupBox;

    private System.Windows.Forms.Button executeBtn;

    private System.Windows.Forms.RadioButton decipherButton;
    private System.Windows.Forms.RadioButton encypherButton;

    private System.Windows.Forms.RadioButton vizhinerButton;

    private System.Windows.Forms.RadioButton decimationButton;

    private System.Windows.Forms.TextBox plainTextBox;
    private System.Windows.Forms.TextBox keyTextbox;

    private System.Windows.Forms.TextBox resultTextBox;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    #endregion
}