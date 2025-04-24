namespace Lab1;

public partial class ChooseTypeForm : Form
{
    public string SelectedFormat = "JSON";
    public string FileName = "";
    public ChooseTypeForm()
    {
        InitializeComponent();
        formatComboBox.Items.AddRange(new[] { "JSON", "XML" });
        formatComboBox.SelectedIndex = 0;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        SelectedFormat = formatComboBox.SelectedItem.ToString();
        FileName = fileTextBox.Text;
        DialogResult = DialogResult.OK;
        Close();
       
    }

    private void fileTextBox_TextChanged(object sender, EventArgs e)
    {
        FileName = fileTextBox.Text;
        if (FileName != "")
        {
            okButton.Enabled = true;
        }
        else
        {
            okButton.Enabled = false;
        }
    }
}