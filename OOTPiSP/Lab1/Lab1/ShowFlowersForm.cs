namespace Lab1;
using System.Reflection;

public partial class ShowFlowersForm : Form
{
    
    private Stack<List<Flower>> undoStack = new Stack<List<Flower>>();
    private Stack<List<Flower>> redoStack = new Stack<List<Flower>>();
    public static Assembly PluginAssembly = Assembly.GetExecutingAssembly();
    private void LoadImages()
    {
        int imgKey = 0;
        foreach (var flower in Program.flowerList)
        {
            Image img = Image.FromFile(flower.PictureURL);
            imageList.Images.Add(imgKey.ToString(), img); 
            imgKey++;
        }
    }

    private void CheckEnabled(Button button, Stack<List<Flower>> stack)
    {
        if (stack.Count > 0)
        {
            button.Enabled = true;
        }
        else
        {
            button.Enabled = false;
        }
    }
    
    private void SaveState()
    {
        List<Flower> copy = new List<Flower>(Program.flowerList.Count);
        foreach (Flower flower in Program.flowerList)
        {
            Flower flowerCopy = flower.Clone();
            copy.Add(flowerCopy);
        }
        undoStack.Push(copy);
        
        CheckEnabled(undoButton, undoStack);
        CheckEnabled(redoButton, redoStack);
    }

    private void AddAllFlowers()
    {
        flowerListView.SmallImageList = imageList;
        int count = 0;
        foreach (var flower in Program.flowerList)
        {
            if (File.Exists(flower.PictureURL))
            {
                ListViewItem item = new ListViewItem();
                item.Text = flower.Name;
                item.ImageIndex = count++;
                flowerListView.Items.Add(flower.Name, item.ImageIndex);

            }
        }
    }
    
    public ShowFlowersForm()
    {
        InitializeComponent();
    }

    private void UpdateListView()
    {
        //SaveState();
        flowerListView.Items.Clear();
        imageList.Images.Clear();
        LoadImages();
        AddAllFlowers();
    }

    private void addNewButton_Click(object sender, EventArgs e)
    {
        SaveState();
        addFlowerForm addFlowerForm = new addFlowerForm();
        addFlowerForm.ShowDialog();
        UpdateListView();
        
    }

    private void flowerListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (flowerListView.SelectedItems.Count > 0)
        {
            deleteButton.Enabled = true;
            editButton.Enabled = true;
            infoButton.Enabled = true;
        }
        else
        {
            deleteButton.Enabled = false;
            editButton.Enabled = false;
            infoButton.Enabled = false;
        }
    }

    private void ShowFlowersForm_Load(object sender, EventArgs e)
    {
        
        LoadImages();
        AddAllFlowers();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (flowerListView.SelectedItems.Count == 0)
        {
            MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        SaveState();
        ListViewItem selectedItem = flowerListView.SelectedItems[0];
        int index = selectedItem.Index;
        if (index >= 0 && index < Program.flowerList.Count)
        {
            Program.flowerList.RemoveAt(index);
        }
        UpdateListView();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        if (flowerListView.SelectedItems.Count == 0)
        {
            MessageBox.Show("Пожалуйста, выберите элемент.", "Изменение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        SaveState();
        ListViewItem selectedItem = flowerListView.SelectedItems[0];
        int index = selectedItem.Index;
        if (index >= 0 && index < Program.flowerList.Count)
        {
            EditFlowerForm editFlowerForm = new EditFlowerForm(Program.flowerList[index]);
            editFlowerForm.ShowDialog();
        }
    }

    private void undoButton_click(object sender, EventArgs e)
    {
        if (undoStack.Count > 0)
        {
            List<Flower> copy = new List<Flower>(Program.flowerList.Count);
            foreach (Flower flower in Program.flowerList)
            {
                Flower flowerCopy = flower.Clone();
                copy.Add(flowerCopy);
            }
            redoStack.Push(copy); // Сохраняем текущее состояние
            Program.flowerList = undoStack.Pop(); // Откатываем предыдущее состояние
            UpdateListView();
            CheckEnabled(undoButton, undoStack);
            CheckEnabled(redoButton, redoStack);
        }
    }

    private void redoButton_Click(object sender, EventArgs e)
    {
        if (redoStack.Count > 0)
        {
            List<Flower> copy = new List<Flower>(Program.flowerList.Count);
            foreach (Flower flower in Program.flowerList)
            {
                Flower flowerCopy = flower.Clone();
                copy.Add(flowerCopy);
            }
            
            undoStack.Push(copy); // Сохраняем текущее состояние
            Program.flowerList = redoStack.Pop(); // Восстанавливаем состояние
            UpdateListView();
            CheckEnabled(undoButton, undoStack);
            CheckEnabled(redoButton, redoStack);
        }
    }

    private void infoButton_Click(object sender, EventArgs e)
    {
        ListViewItem selectedItem = flowerListView.SelectedItems[0];
        int index = selectedItem.Index;
        ShowPropertiesForm showPropertiesForm = new ShowPropertiesForm(Program.flowerList[index]);
        showPropertiesForm.ShowDialog();
    }

    private void serializationButton_Click(object sender, EventArgs e)
    {
        ChooseTypeForm chooseTypeForm = new ChooseTypeForm();
        if (chooseTypeForm.ShowDialog() == DialogResult.OK)
        {
            string selectedFormat = chooseTypeForm.SelectedFormat;
            string fileName = chooseTypeForm.FileName;
            if (selectedFormat == "JSON")
            {
                fileName += ".json";
                FlowerJsonSerializer serializer = new FlowerJsonSerializer();
                serializer.Serialize(Program.flowerList, fileName);
                MessageBox.Show("Список цветов успешно сериализован!");
            }
            else if (selectedFormat == "XML")
            {
                fileName += ".xml";
                FlowerXmlSerializer serializer = new FlowerXmlSerializer();
                serializer.Serialize(Program.flowerList, fileName);
                MessageBox.Show("Список цветов успешно сериализован!");
            }
        }
        
    }
    
    private bool CheckFileExists(string filePath)
    {
        if (!File.Exists(filePath))
        {
            MessageBox.Show($"Файл \"{filePath}\" не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }


    private void deserializationButton_Click(object sender, EventArgs e)
    {
        ChooseTypeForm chooseTypeForm = new ChooseTypeForm();
        if (chooseTypeForm.ShowDialog() == DialogResult.OK)
        {
            string selectedFormat = chooseTypeForm.SelectedFormat;
            string fileName = chooseTypeForm.FileName;

            try
            {
                if (selectedFormat == "JSON")
                {
                    fileName += ".json";
                    if (!CheckFileExists(fileName)) return;

                    FlowerJsonSerializer deserializer = new FlowerJsonSerializer();
                    Program.flowerList = deserializer.Deserialize(fileName);
                }
                else if (selectedFormat == "XML")
                {
                    fileName += ".xml";
                    if (!CheckFileExists(fileName)) return;
                    FlowerXmlSerializer deserializer = new FlowerXmlSerializer();
                    Program.flowerList = deserializer.Deserialize(fileName);
                }

                UpdateListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при десериализации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    private void addClass_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialogDll = new OpenFileDialog();
        openFileDialogDll.Filter = "DLL files (*.dll)|*.dll";
        openFileDialogDll.Title = "Выберите DLL плагина";

        if (openFileDialogDll.ShowDialog() == DialogResult.OK)
        {
            PluginAssembly = Assembly.LoadFrom(openFileDialogDll.FileName);
            var pluginTypes = PluginAssembly.GetTypes()
                .Where(t => typeof(Flower).IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            addFlowerForm.FlowerTypeNames = addFlowerForm.FlowerTypeNames
                .Concat(pluginTypes
                    .Where(t => !addFlowerForm.FlowerTypeNames.Contains(t.Name))  // Проверка на существование
                    .Select(t => t.Name))
                .ToArray();

        }
    }
}