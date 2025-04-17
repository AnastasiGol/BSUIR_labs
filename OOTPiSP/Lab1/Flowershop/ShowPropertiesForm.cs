namespace Lab1;

public partial class ShowPropertiesForm : Form
{
    private Flower currFlower;
    public ShowPropertiesForm(Flower flower)
    {
        InitializeComponent();
        currFlower = flower;
        infoLabel.Text = currFlower.ToString();
    }
    




    private void label1_Click_1(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }
}