namespace Lab1;
using Lab1;


public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
        
    }

    private void label1_Click(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }



    private void executeBtn_Click(object sender, EventArgs e)
    {
        string plaintext;
        string result = "";
            if (encypherButton.Checked && decimationButton.Checked && isKeyIntCorrect())
            {
                plaintext = plainTextBox.Text.ToLower();
                int key = int.Parse(keyTextbox.Text);
                result = TextProcessor.DecimationEncryption(plaintext, key);
            }
            else if ((decipherButton.Checked && decimationButton.Checked && isKeyIntCorrect()))
            {
                plaintext = plainTextBox.Text.ToLower();
                int key = int.Parse(keyTextbox.Text);
                result = TextProcessor.DecimationDecryption(plaintext, key);
            }
            else if (encypherButton.Checked && vizhinerButton.Checked && isKeyShorter())
            {
                plaintext = plainTextBox.Text.ToLower();
                string key = keyTextbox.Text;
                result = TextProcessor.VizhinerEncryption(plaintext, key);
            }
            else if (decipherButton.Checked && vizhinerButton.Checked && isKeyShorter())
            {
                plaintext = plainTextBox.Text.ToLower();
                string key = keyTextbox.Text;
                result = TextProcessor.VizhinerDecryption(plaintext, key);
            }
            else
            {
                MessageBox.Show("Данные введены некорректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            resultTextBox.Text = result.ToUpper();
            writeFileBtn.Visible = true;
        
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    private void fileBtn_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    plainTextBox.Text = File.ReadLines(openFileDialog.FileName).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void writeFileBtn_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    File.WriteAllText(filePath, resultTextBox.Text);
                    MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }

    private void plainTextBoxChanged(object sender, EventArgs e)
    {
        UpdateButtonState();
    }
    
    private void UpdateButtonState()
    {
        executeBtn.Enabled = !string.IsNullOrWhiteSpace(plainTextBox.Text) && !string.IsNullOrWhiteSpace(keyTextbox.Text);
    }

    private void keyTextboxChanged(object sender, EventArgs e)
    {
        UpdateButtonState();
    }

    private bool isKeyShorter()
    {
        return keyTextbox.Text.Length < plainTextBox.Text.Length;
    }

    private bool isKeyIntCorrect()
    {
        
        return int.TryParse(keyTextbox.Text, out _) && int.Parse(keyTextbox.Text) < 33 && int.Parse(keyTextbox.Text) > 0 && (GCD(int.Parse(keyTextbox.Text), 33) == 1);
    }
    
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}