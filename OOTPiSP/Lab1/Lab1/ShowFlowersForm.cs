namespace Lab1;

public partial class ShowFlowersForm : Form
{

    private void AddAllFlowers()
    {
        foreach (var flower in Program.flowerList)
        {
            flowersBox.Items.Add(flower.ToString());
        }
    }
    public ShowFlowersForm()
    {
        InitializeComponent();
        AddAllFlowers();
    }

    private void label1_Click(object sender, EventArgs e)
    {
       // throw new System.NotImplementedException();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    private void UpdateListbox()
    {
        flowersBox.Items.Clear();
        AddAllFlowers();
    }

    private void addNewButton_Click(object sender, EventArgs e)
    {
        addFlowerForm addFlowerForm = new addFlowerForm();
        addFlowerForm.ShowDialog();
        UpdateListbox();
    }
}