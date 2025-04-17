using System.Reflection;

namespace Lab1;

public partial class EditFlowerForm : Form
{
    private Flower currFlower;
    public EditFlowerForm()
    {
        InitializeComponent();
        
    }
    
    public EditFlowerForm(Flower flower)
    {
        currFlower = flower;
        InitializeComponent();
        
    }

    private void label1_Click(object sender, EventArgs e)
    {
        //throw new System.NotImplementedException();
    }
    
    

    private void EditFlowerForm_Load(object sender, EventArgs e)
    {
        nameLabel.Text = currFlower.Name;
        List<PropertyInfo> propNames = currFlower.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
            .Where(prop => prop.Name != nameof(currFlower.PictureURL) && prop.Name != nameof(currFlower.Name))
            .ToList();
        
        AddProperties(propNames);
        LoadPropertiesField(propNames);
    }
    
        private Panel CreatePropertiesPanel()
    {
        Panel panel = new Panel
        {
            AutoSize = true,
            Location = new Point(0, 0),
            Name = "propertiesPanel"
        };
        return panel;
    }
    
    private Label CreateLabel(string propertyName, int x, int y, Size size)
    {
        return new Label
        {
            Text = propertyName,
            Location = new Point(x, y),
            Name = $"{propertyName}Label",
            Size = size
        };
    }
    
    private ComboBox CreateComboBox(string propertyName, int x, int y, Size size)
    {
        return new ComboBox
        {
            Items = { "True", "False" },
            DropDownStyle = ComboBoxStyle.DropDownList,
            SelectedIndex = 0,
            Location = new Point(x, y),
            Name = $"{propertyName}ComboBox",
            Size = size
        };
    }
    
    private TextBox CreateTextBox(string propertyName, int x, int y, Size size)
    {
        return new TextBox
        {
            Location = new Point(x, y),
            Name = $"{propertyName}TextBox",
            Size = size
        };
    }

    private void AddProperties(List<PropertyInfo> properties)
    {
        int offset = 50;
        int labelX = 30, labelY = 100;
        int textX = 280, textY= 100;
        Size size = new Size(170, 30);
        Panel panel = CreatePropertiesPanel();
        
        
        foreach (var property in properties)
        {
            Label label = CreateLabel(property.Name, labelX, labelY, size);
            
            Control inputControl;
            
            
            if (property.PropertyType == typeof(bool))
            {
                ComboBox comboBox = CreateComboBox(property.Name, textX, textY, size);
                panel.Controls.Add(comboBox);
                inputControl = comboBox;
            }
            else
            {
                TextBox textBox = CreateTextBox(property.Name, textX, textY, size);
                panel.Controls.Add(textBox);
                inputControl = textBox;
            }
            panel.Controls.Add(label);
            panel.Controls.Add(inputControl);
            
            textY +=  offset;
            labelY += offset;
            
        }
        Controls.Add(panel);
        
    }

    private void LoadPropertiesField(List<PropertyInfo> propNames)
    {
        Panel panel = Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "propertiesPanel");
        if (panel == null) return;

        // Проходим по всем свойствам
        foreach (var prop in propNames)
        {
            Control control = panel.Controls.Find($"{prop.Name}TextBox", true).FirstOrDefault()
                              ?? panel.Controls.Find($"{prop.Name}ComboBox", true).FirstOrDefault();

            if (control != null)
            {
                object value = prop.GetValue(currFlower);
                if (control is TextBox textBox)
                {
                    textBox.Text = value?.ToString() ?? "";
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedItem = value?.ToString();
                }
            }
        }
    }

    bool HasEmptyFields(object obj)
    {
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            object value = prop.GetValue(obj);

            if (value == null || 
                (value is string str && string.IsNullOrWhiteSpace(str)) || 
                (value is int num && num == 0))
            {
                return true; //  пустое поле
            }
        }
        return false; 
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (!HasEmptyFields(currFlower))
        {
            List<PropertyInfo> propNames = currFlower.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .Where(prop => prop.Name != nameof(currFlower.PictureURL) && prop.Name != nameof(currFlower.Name))
                .ToList();

            Panel panel = Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "propertiesPanel");
            if (panel == null) return;

            foreach (var prop in propNames)
            {
                Control control = panel.Controls.Find($"{prop.Name}TextBox", true).FirstOrDefault()
                                  ?? panel.Controls.Find($"{prop.Name}ComboBox", true).FirstOrDefault();

                if (control != null)
                {
                    try
                    {
                        if (control is TextBox textBox)
                        {
                            object convertedValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
                            prop.SetValue(currFlower, convertedValue);
                        }
                        else if (control is ComboBox comboBox)
                        {
                            object convertedValue = Convert.ChangeType(comboBox.SelectedItem, prop.PropertyType);
                            prop.SetValue(currFlower, convertedValue);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении {prop.Name}: {ex.Message}");
                    }
                }
            }

            MessageBox.Show("Изменения сохранены!");
            Close();
        }
    }
}