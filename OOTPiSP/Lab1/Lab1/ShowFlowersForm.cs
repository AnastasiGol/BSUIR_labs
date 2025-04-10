namespace Lab1;

public partial class ShowFlowersForm : Form
{
    
    private Stack<List<Flower>> undoStack = new Stack<List<Flower>>();
    private Stack<List<Flower>> redoStack = new Stack<List<Flower>>();
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
        undoStack.Push(new List<Flower>(Program.flowerList));
        //redoStack.Clear(); 
        
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
        SaveState();
        ListViewItem selectedItem = flowerListView.SelectedItems[0];
        int index = selectedItem.Index;
        if (index >= 0 && index < Program.flowerList.Count)
        {
            Program.flowerList.RemoveAt(index);
        }
        //flowerListView.Items.Remove(selectedItem);



        UpdateListView();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        SaveState();
        ListViewItem selectedItem = flowerListView.SelectedItems[0];
        int index = selectedItem.Index;
        EditFlowerForm editFlowerForm = new EditFlowerForm(Program.flowerList[index]);
        editFlowerForm.ShowDialog();
    }

    private void undoButton_click(object sender, EventArgs e)
    {
        if (undoStack.Count > 0)
        {
            redoStack.Push(Program.flowerList); // Сохраняем текущее состояние
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
            undoStack.Push(Program.flowerList); // Сохраняем текущее состояние
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
}