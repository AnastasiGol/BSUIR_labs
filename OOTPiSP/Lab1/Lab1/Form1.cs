namespace Lab1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        List<PictureBox> flowerBoxList = new List<PictureBox>()
        {
            flowerBox1,
            flowerBox2,
            flowerBox3,
            flowerBox4,
            flowerBox5,
            flowerBox6
        };
        
        List<Label> labels = new List<Label> { label1, label2, label3, label4, label5, label6 };
        List<Flower> flowerList = new List<Flower>()
        {
            new Cornflower(),
            new Daisy(),
            new Orchid(),
            new Peone(),
            new Rose(),
            new Tulip()
        
        };
        for (int i = 0; i < flowerList.Count; i++)
        {
            LoadFlowerImage(flowerList[i], flowerBoxList[i], labels[i]);
        }
       
        
        
    }
    

    private void LoadFlowerImage(Flower flower, PictureBox picturebox, Label label){
        picturebox.Image = Image.FromFile(flower.pictureURL);
        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        label.Text = flower.name;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }
}