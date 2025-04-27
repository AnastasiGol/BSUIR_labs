namespace Lab1;
using System.Reflection;
public partial class MainForm : Form
{
    //public static Assembly PluginAssembly = Assembly.GetExecutingAssembly();
    public MainForm()
    {
        InitializeComponent();
        List<PictureBox> flowerBoxList = new List<PictureBox>()
        {
            flowerBox1,
            flowerBox2,
            flowerBox3,
            flowerBox4,
            flowerBox5,
            flowerBox6,
            //flowerBox7
        };
        
        List<Label> labels = new List<Label> { label1, label2, label3, label4, label5, label6 };
        List<Flower> flowerList = new List<Flower>()
        {
            new Cornflower(),
            new Daisy(),
            new Orchid(),
            new Peone(),
            new Rose(),
            new Tulip(),
            //new Sunflower()
        
        };
        for (int i = 0; i < flowerList.Count; i++)
        {
            LoadFlowerImage(flowerList[i], flowerBoxList[i], labels[i]);
        }
        
    }
    

    private void LoadFlowerImage(Flower flower, PictureBox picturebox, Label label){
        picturebox.Image = Image.FromFile(flower.PictureURL);
        picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
        label.Text = flower.Name;
    }

    private void myFlowersBtn_Click(object sender, EventArgs e)
    {
        ShowFlowersForm showFlowersForm = new ShowFlowersForm();
        showFlowersForm.ShowDialog();
    }

    

}