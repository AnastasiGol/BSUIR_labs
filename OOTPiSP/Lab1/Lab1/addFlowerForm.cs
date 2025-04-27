using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab1;


public partial class addFlowerForm : Form
{
    public static string[] FlowerTypeNames = typeof(Flower).Assembly.GetTypes()  
        .Where(t => t.IsSubclassOf(typeof(Flower)) && !t.IsAbstract) //  наследники Flower
        .Select(t => t.Name)
        .ToArray();
    public Type[] FlowerTypes { get; set; } = Array.Empty<Type>();
    
    
    private Type flowerType;
    
    private MainForm mainForm;
    
    public addFlowerForm()
    {
        InitializeComponent();
        LoadFlowerTypes();
    }
    
    private void LoadFlowerTypes()
    {
        flowersComboBox.Items.AddRange(FlowerTypeNames);
    }

    private Dictionary<string, object> GetProperties(Type type)
    {
        Dictionary<string, object> enteredProperties = new Dictionary<string, object>();
        
        Panel panel = Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "propertiesPanel");
        if (panel == null)
        {
            MessageBox.Show("Панель со свойствами не найдена!");
            return enteredProperties;
        }

        foreach (var property in type.GetProperties())
        {
            string propertyName = property.Name;
            Control inputControl = panel.Controls[$"{propertyName}TextBox"] ?? panel.Controls[$"{propertyName}ComboBox"];

            if (inputControl is TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
            {
                try
                {
                    object convertedValue = Convert.ChangeType(textBox.Text, property.PropertyType);
                    enteredProperties[propertyName] = convertedValue;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Ошибка преобразования для {propertyName}. Проверьте формат данных.");
                }
            }
            else if (inputControl is ComboBox comboBox)
            {
                if (property.PropertyType == typeof(bool))
                {
                    enteredProperties[propertyName] = comboBox.SelectedItem.ToString() == "True";
                }
                else
                {
                    enteredProperties[propertyName] = comboBox.SelectedItem.ToString();
                }
            }
        }

        return enteredProperties;
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
                return true; 
            }
        }
        return false; 
    }
    
    private bool IsTypeAlreadyLoaded(Type type)
    {
        // все типы из текущей сборки
        var loadedTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .ToList();

        // существует ли уже тип с таким именем
        return loadedTypes.Any(t => t == type);
    }
    
    private void addButton_Click(object sender, EventArgs e)
    {
        string stringType = flowersComboBox.SelectedItem.ToString() ?? string.Empty;

        Type flowerType = Type.GetType("Lab1." + stringType) ?? ShowFlowersForm.PluginAssembly.GetTypes()
            .FirstOrDefault(t => t.Name == stringType && typeof(Flower).IsAssignableFrom(t)) ?? typeof(object);
        Dictionary<string, object> properties = GetProperties(flowerType);
        object flowerInstance = Activator.CreateInstance(flowerType) ;

        bool hasError = false;
        foreach (var property in properties)
        {
            PropertyInfo propInfo = flowerType.GetProperty(property.Key);
            try
            {
                object convertedValue = Convert.ChangeType(property.Value, propInfo.PropertyType);
                propInfo.SetValue(flowerInstance, convertedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при установке свойства {property.Key}\nПопробуйте еще раз");
                hasError = true;
            }    
        }
        if (!hasError && HasEmptyFields(flowerInstance))
        {
            MessageBox.Show("Некоторые поля пустые. Заполните их перед добавлением.");
            hasError = true;
        }

        if (!hasError)
        {
            Program.flowerList.Add((Flower)flowerInstance);
            Close();
        }

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
        int labelX = 30, labelY = 280;
        int textX = 280, textY= 280;
        int startX = 0, startY = 0;
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

    private void ClearPanel()
    {
        var panel = Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "propertiesPanel");
    
        if (panel != null)
        {
            Controls.Remove(panel); 
            panel.Dispose();
        }
    }

    private void flowersComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearPanel();
        if (flowersComboBox.SelectedItem == null) return;
        addButton.Visible = true;
        string stringType = flowersComboBox.SelectedItem.ToString() ?? string.Empty;
        if (stringType != string.Empty)
        {
            Type flowerType = Assembly.GetExecutingAssembly().GetType("Lab1." + stringType) ?? typeof(Flower);
            
            List<PropertyInfo> propNames = flowerType.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy
            ).Where(prop => prop.Name != "PictureURL" && prop.Name != "Name").ToList();
            AddProperties(propNames);

        }


    }

}