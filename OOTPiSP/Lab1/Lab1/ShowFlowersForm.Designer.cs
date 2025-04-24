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
        components = new System.ComponentModel.Container();
        label1 = new System.Windows.Forms.Label();
        addNewButton = new System.Windows.Forms.Button();
        deleteButton = new System.Windows.Forms.Button();
        imageList = new System.Windows.Forms.ImageList(components);
        flowerListView = new System.Windows.Forms.ListView();
        editButton = new System.Windows.Forms.Button();
        undoButton = new System.Windows.Forms.Button();
        redoButton = new System.Windows.Forms.Button();
        infoButton = new System.Windows.Forms.Button();
        serializationButton = new System.Windows.Forms.Button();
        deserializationButton = new System.Windows.Forms.Button();
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
        // 
        // addNewButton
        // 
        addNewButton.Location = new System.Drawing.Point(12, 689);
        addNewButton.Name = "addNewButton";
        addNewButton.Size = new System.Drawing.Size(1064, 74);
        addNewButton.TabIndex = 2;
        addNewButton.Text = "Добавить новый";
        addNewButton.UseVisualStyleBackColor = true;
        addNewButton.Click += addNewButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Enabled = false;
        deleteButton.Location = new System.Drawing.Point(12, 769);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new System.Drawing.Size(343, 74);
        deleteButton.TabIndex = 3;
        deleteButton.Text = "Удалить";
        deleteButton.UseVisualStyleBackColor = true;
        deleteButton.Click += deleteButton_Click;
        // 
        // imageList
        // 
        imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        imageList.ImageSize = new System.Drawing.Size(100, 100);
        imageList.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // flowerListView
        // 
        flowerListView.LargeImageList = imageList;
        flowerListView.Location = new System.Drawing.Point(12, 87);
        flowerListView.Name = "flowerListView";
        flowerListView.Size = new System.Drawing.Size(1050, 566);
        flowerListView.SmallImageList = imageList;
        flowerListView.TabIndex = 4;
        flowerListView.UseCompatibleStateImageBehavior = false;
        flowerListView.View = System.Windows.Forms.View.SmallIcon;
        flowerListView.SelectedIndexChanged += flowerListView_SelectedIndexChanged;
        // 
        // editButton
        // 
        editButton.Enabled = false;
        editButton.Location = new System.Drawing.Point(710, 769);
        editButton.Name = "editButton";
        editButton.Size = new System.Drawing.Size(332, 74);
        editButton.TabIndex = 5;
        editButton.Text = "Изменить";
        editButton.UseVisualStyleBackColor = true;
        editButton.Click += editButton_Click;
        // 
        // undoButton
        // 
        undoButton.Enabled = false;
        undoButton.Location = new System.Drawing.Point(460, 924);
        undoButton.Name = "undoButton";
        undoButton.Size = new System.Drawing.Size(90, 74);
        undoButton.TabIndex = 6;
        undoButton.Text = "<";
        undoButton.UseVisualStyleBackColor = true;
        undoButton.Click += undoButton_click;
        // 
        // redoButton
        // 
        redoButton.Enabled = false;
        redoButton.Location = new System.Drawing.Point(556, 924);
        redoButton.Name = "redoButton";
        redoButton.Size = new System.Drawing.Size(90, 74);
        redoButton.TabIndex = 7;
        redoButton.Text = ">";
        redoButton.UseVisualStyleBackColor = true;
        redoButton.Click += redoButton_Click;
        // 
        // infoButton
        // 
        infoButton.Enabled = false;
        infoButton.Location = new System.Drawing.Point(361, 769);
        infoButton.Name = "infoButton";
        infoButton.Size = new System.Drawing.Size(343, 74);
        infoButton.TabIndex = 8;
        infoButton.Text = "Подробнее";
        infoButton.UseVisualStyleBackColor = true;
        infoButton.Click += infoButton_Click;
        // 
        // serializationButton
        // 
        serializationButton.Location = new System.Drawing.Point(290, 848);
        serializationButton.Name = "serializationButton";
        serializationButton.Size = new System.Drawing.Size(260, 70);
        serializationButton.TabIndex = 9;
        serializationButton.Text = "Сериализовать";
        serializationButton.UseVisualStyleBackColor = true;
        serializationButton.Click += serializationButton_Click;
        // 
        // deserializationButton
        // 
        deserializationButton.Location = new System.Drawing.Point(556, 849);
        deserializationButton.Name = "deserializationButton";
        deserializationButton.Size = new System.Drawing.Size(245, 70);
        deserializationButton.TabIndex = 10;
        deserializationButton.Text = "Десериализовать";
        deserializationButton.UseVisualStyleBackColor = true;
        deserializationButton.Click += deserializationButton_Click;
        // 
        // ShowFlowersForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1078, 1003);
        Controls.Add(deserializationButton);
        Controls.Add(serializationButton);
        Controls.Add(infoButton);
        Controls.Add(redoButton);
        Controls.Add(undoButton);
        Controls.Add(editButton);
        Controls.Add(flowerListView);
        Controls.Add(deleteButton);
        Controls.Add(addNewButton);
        Controls.Add(label1);
        Text = "Мои цветы";
        Load += ShowFlowersForm_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button serializationButton;
    private System.Windows.Forms.Button deserializationButton;

    private System.Windows.Forms.Button infoButton;

    private System.Windows.Forms.Button editButton;
    private System.Windows.Forms.Button undoButton;
    private System.Windows.Forms.Button redoButton;

    private System.Windows.Forms.ListView flowerListView;

    private System.Windows.Forms.ImageList imageList;

    private System.Windows.Forms.Button addNewButton;
    private System.Windows.Forms.Button deleteButton;

    private System.Windows.Forms.Label label1;

    #endregion
}