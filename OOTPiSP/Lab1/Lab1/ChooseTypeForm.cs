namespace Lab1;

public partial class ChooseTypeForm : Form
{
    public string SelectedFormat = "JSON";
    public string FileName = "";
    public static bool ShouldEncrypt = false;
    public ChooseTypeForm()
    {
        InitializeComponent();
        formatComboBox.Items.AddRange(new[] { "JSON", "XML" });
        formatComboBox.SelectedIndex = 0;
        encryptComboBox.Items.AddRange(new[] {"No", "Yes"});
        encryptComboBox.SelectedIndex = 0;
    }

    private bool EncryptChoice()
    {
        return encryptComboBox.SelectedItem?.ToString() == "Yes";
    }


    private void okButton_Click(object sender, EventArgs e)
    {
        ShouldEncrypt = EncryptChoice();
        if (ShouldEncrypt)
        {
            OpenFileDialog openFileDialogDll = new OpenFileDialog();
            openFileDialogDll.Filter = "DLL files (*.dll)|*.dll";
            openFileDialogDll.Title = "Выберите DLL плагина";
        }
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





    private void ChoosTypeForm_Load_1(object sender, EventArgs e)
    {
        //
    }
}