namespace Lab1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        flowerLabel = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        flowerBox1 = new System.Windows.Forms.PictureBox();
        flowerBox2 = new System.Windows.Forms.PictureBox();
        flowerBox3 = new System.Windows.Forms.PictureBox();
        flowerBox4 = new System.Windows.Forms.PictureBox();
        flowerBox5 = new System.Windows.Forms.PictureBox();
        flowerBox6 = new System.Windows.Forms.PictureBox();
        addFlowerBtn = new System.Windows.Forms.Button();
        myFlowersBtn = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)flowerBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox4).BeginInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox5).BeginInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox6).BeginInit();
        SuspendLayout();
        // 
        // flowerLabel
        // 
        flowerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        flowerLabel.Location = new System.Drawing.Point(489, 41);
        flowerLabel.Name = "flowerLabel";
        flowerLabel.Size = new System.Drawing.Size(252, 60);
        flowerLabel.TabIndex = 0;
        flowerLabel.Text = "Flowershop";
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(177, 144);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(215, 59);
        label1.TabIndex = 1;
        label1.Text = "Wildflowers";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        label2.Location = new System.Drawing.Point(773, 144);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(215, 59);
        label2.TabIndex = 2;
        label2.Text = "Gardenflowers";
        // 
        // flowerBox1
        // 
        flowerBox1.Location = new System.Drawing.Point(21, 218);
        flowerBox1.Name = "flowerBox1";
        flowerBox1.Size = new System.Drawing.Size(193, 151);
        flowerBox1.TabIndex = 3;
        flowerBox1.TabStop = false;
        // 
        // flowerBox2
        // 
        flowerBox2.Location = new System.Drawing.Point(316, 218);
        flowerBox2.Name = "flowerBox2";
        flowerBox2.Size = new System.Drawing.Size(193, 151);
        flowerBox2.TabIndex = 4;
        flowerBox2.TabStop = false;
        // 
        // flowerBox3
        // 
        flowerBox3.Location = new System.Drawing.Point(637, 386);
        flowerBox3.Name = "flowerBox3";
        flowerBox3.Size = new System.Drawing.Size(193, 151);
        flowerBox3.TabIndex = 5;
        flowerBox3.TabStop = false;
        // 
        // flowerBox4
        // 
        flowerBox4.Location = new System.Drawing.Point(637, 206);
        flowerBox4.Name = "flowerBox4";
        flowerBox4.Size = new System.Drawing.Size(193, 151);
        flowerBox4.TabIndex = 6;
        flowerBox4.TabStop = false;
        // 
        // flowerBox5
        // 
        flowerBox5.Location = new System.Drawing.Point(934, 206);
        flowerBox5.Name = "flowerBox5";
        flowerBox5.Size = new System.Drawing.Size(193, 151);
        flowerBox5.TabIndex = 7;
        flowerBox5.TabStop = false;
        // 
        // flowerBox6
        // 
        flowerBox6.Location = new System.Drawing.Point(934, 386);
        flowerBox6.Name = "flowerBox6";
        flowerBox6.Size = new System.Drawing.Size(193, 151);
        flowerBox6.TabIndex = 8;
        flowerBox6.TabStop = false;
        // 
        // addFlowerBtn
        // 
        addFlowerBtn.Location = new System.Drawing.Point(177, 610);
        addFlowerBtn.Name = "addFlowerBtn";
        addFlowerBtn.Size = new System.Drawing.Size(247, 83);
        addFlowerBtn.TabIndex = 9;
        addFlowerBtn.Text = "Добавить цветок";
        addFlowerBtn.UseVisualStyleBackColor = true;
        addFlowerBtn.Click += button1_Click;
        // 
        // myFlowersBtn
        // 
        myFlowersBtn.Location = new System.Drawing.Point(741, 610);
        myFlowersBtn.Name = "myFlowersBtn";
        myFlowersBtn.Size = new System.Drawing.Size(247, 83);
        myFlowersBtn.TabIndex = 10;
        myFlowersBtn.Text = "Мои цветы";
        myFlowersBtn.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1178, 733);
        Controls.Add(myFlowersBtn);
        Controls.Add(addFlowerBtn);
        Controls.Add(flowerBox6);
        Controls.Add(flowerBox5);
        Controls.Add(flowerBox4);
        Controls.Add(flowerBox3);
        Controls.Add(flowerBox2);
        Controls.Add(flowerBox1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(flowerLabel);
        MaximumSize = new System.Drawing.Size(1200, 789);
        MinimumSize = new System.Drawing.Size(1200, 789);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)flowerBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox3).EndInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox4).EndInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox5).EndInit();
        ((System.ComponentModel.ISupportInitialize)flowerBox6).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button addFlowerBtn;

    private System.Windows.Forms.Button myFlowersBtn;

    private System.Windows.Forms.PictureBox flowerBox2;
    private System.Windows.Forms.PictureBox flowerBox3;
    private System.Windows.Forms.PictureBox flowerBox4;
    private System.Windows.Forms.PictureBox flowerBox5;

    private System.Windows.Forms.PictureBox flowerBox6;

    private System.Windows.Forms.PictureBox flowerBox1;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label flowerLabel;

    #endregion
}