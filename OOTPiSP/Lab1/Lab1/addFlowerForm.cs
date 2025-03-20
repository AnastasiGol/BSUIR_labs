using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab1;


public partial class addFlowerForm : Form
{
    
    
    private Type flowerType;
    
    private MainForm mainForm;
    
    public addFlowerForm()
    {
        InitializeComponent();
        LoadFlowerTypes();
    }
    
    private void LoadFlowerTypes()
    {
        var flowerTypes = typeof(Flower).Assembly.GetTypes()  
            .Where(t => t.IsSubclassOf(typeof(Flower)) && !t.IsAbstract) // Только наследники Flower
            .Select(t => t.Name) // Берем имена классов
            .ToArray();
        flowersComboBox.Items.AddRange(flowerTypes);
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

        foreach (TextBox textBox in panel.Controls.OfType<TextBox>())
        {
   
            string labelName = textBox.Name.Replace("TextBox", "Label");
            Label label = panel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == labelName);
            if (label == null)
            {
                MessageBox.Show($"Не найден Label для {textBox.Name}");
                continue;
            }
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                enteredProperties[label.Text] = textBox.Text;
            }
        }
        return enteredProperties;
    }


    private static void AddFlower( Dictionary<string, object> properties)
    {
       // object flowerInstance = Activator.CreateInstance(flowerType);
    }
    
    private void addButton_Click(object sender, EventArgs e)
    {
        string stringType = flowersComboBox.SelectedItem.ToString();
        
        Type flowerType = Type.GetType("Lab1." + stringType);
        Dictionary<string, object> properties = GetProperties(flowerType);
        object flowerInstance = Activator.CreateInstance(flowerType);
        foreach (var property in properties)
        {
            PropertyInfo propInfo = flowerType.GetProperty(property.Key);
            if (propInfo != null )
                try
                {
                    object convertedValue = Convert.ChangeType(property.Value, propInfo.PropertyType);
                    propInfo.SetValue(flowerInstance, convertedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при установке свойства {property.Key}: {ex.Message}");
                }
        }
        Program.flowerList.Add((Flower)flowerInstance);
        this.Close();
   
    }

    private void AddProperties(List<PropertyInfo> properties)
    {
        int offset = 50;
        int labelX = 30, labelY = 280;
        int textX = 280, textY= 280;
        int startX = 0, startY = 0;
        Size size = new Size(170, 30);
        Panel panel = new Panel();
        panel.AutoSize = true;
        panel.Location = new Point(startX, startY);
        panel.Name = "propertiesPanel";
        
        foreach (var property in properties)
        {
            Label label = new Label();
            label.Text = property.Name;
            label.Location = new Point(labelX, labelY);
            label.Name = ($"{property}Label");
            label.Size = size;
            
            TextBox textBox = new TextBox();
            textBox.Location = new Point(textX, textY);
            textBox.Name = ($"{property}TextBox");
            textBox.Size = size;
            
            panel.Controls.Add(label);
            panel.Controls.Add(textBox);
            
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
            //что за херня
            panel.Controls.Clear();
            Console.WriteLine("Panel 'propertiesPanel' cleared.");
        }
        else
        {
            Console.WriteLine("Panel 'propertiesPanel' not found.");
        }
    }

    private void flowersComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearPanel();
        if (flowersComboBox.SelectedItem == null) return;
        addButton.Visible = true;
        string stringType = flowersComboBox.SelectedItem.ToString();
        if (stringType != null)
        {
            Type flowerType = Assembly.GetExecutingAssembly().GetType("Lab1." + stringType);


            List<PropertyInfo> propNames = flowerType.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy
            ).Where(prop => prop.Name != "PictureURL" && prop.Name != "Name").ToList();
            AddProperties(propNames);

        }


    }
}