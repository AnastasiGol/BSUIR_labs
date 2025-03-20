namespace Lab1;

public partial class ShowFlowersForm : Form
{
    public ShowFlowersForm()
    {
        InitializeComponent();
        foreach (var flower in Program.flowerList)
        {
            listBox1.Items.Add(flower.ToString());
        }
    }

    private void label1_Click(object sender, EventArgs e)
    {
       // throw new System.NotImplementedException();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }
}