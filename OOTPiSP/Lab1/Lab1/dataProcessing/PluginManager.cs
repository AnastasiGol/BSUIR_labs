using System.Runtime.CompilerServices;

namespace Lab1.dataProcessing;

using System.Reflection;

public class PluginManager
{
    public static IDataProcessorPlugin CurrentPlugin { get; set; }

    public PluginManager()
    {
        ResolvePlugin();
    }

    private void ResolvePlugin()
    {
        OpenFileDialog openFileDialogDll = new OpenFileDialog();
        openFileDialogDll.Filter = "DLL files (*.dll)|*.dll";
        openFileDialogDll.Title = "Выберите DLL плагина";

        if (openFileDialogDll.ShowDialog() == DialogResult.OK)
        {
            Assembly pluginAssembly = Assembly.LoadFrom(openFileDialogDll.FileName);

            // тип, который реализует интерфейс IDataProcessorPlugin
            var pluginType = pluginAssembly.GetTypes()
                .FirstOrDefault(t => typeof(IDataProcessorPlugin).IsAssignableFrom(t) && !t.IsAbstract);

            if (pluginType != null)
            {
                CurrentPlugin = (IDataProcessorPlugin)Activator.CreateInstance(pluginType);
            }
            else
            {
                MessageBox.Show("В выбранной DLL не найден плагин, реализующий IDataProcessorPlugin.");
            }
        }
    }

    public byte[] Encrypt(byte[] data)
    {
        return CurrentPlugin != null ? CurrentPlugin.ProcessBeforeSave(data) : data;
    }

    public byte[] Decrypt(byte[] data)
    {
        return CurrentPlugin != null ? CurrentPlugin.ProcessAfterLoad(data) : data;
    }
}
