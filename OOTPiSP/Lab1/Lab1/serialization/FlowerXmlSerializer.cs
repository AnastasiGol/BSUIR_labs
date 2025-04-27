using Lab1.dataProcessing;

namespace Lab1;
using System.Xml.Serialization;

public class FlowerXmlSerializer: ISerializer
{
    public static Type[] KnownTypes = new Type[]
    {
        typeof(Tulip), typeof(Rose), typeof(Peone), typeof(Orchid),
        typeof(Daisy), typeof(Cornflower)
    };

    public void Serialize(List<Flower> flowers, string filePath)
    {
        if (ChooseTypeForm.ShouldEncrypt)
        {
            PluginManager manager = new PluginManager();
            
            var serializer = new XmlSerializer(typeof(List<Flower>), KnownTypes);
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, flowers);
                byte[] xmlBytes = memoryStream.ToArray();

                byte[] encryptedBytes = manager.Encrypt(xmlBytes);
                File.WriteAllBytes(filePath, encryptedBytes);
            }
        }
        else
        {
            var serializer = new XmlSerializer(typeof(List<Flower>), KnownTypes);
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, flowers);
            }
        }

    }
    
    public List<Flower> Deserialize(string filePath)
    {
        if (ChooseTypeForm.ShouldEncrypt)
        {
            PluginManager manager = new PluginManager();
            byte[] encryptedBytes = File.ReadAllBytes(filePath);
            byte[] decryptedBytes = manager.Decrypt(encryptedBytes);

            var serializer = new XmlSerializer(typeof(List<Flower>), KnownTypes);
            using (var memoryStream = new MemoryStream(decryptedBytes))
            {
                return (List<Flower>)serializer.Deserialize(memoryStream);
            }
        }
        else
        {
            var serializer = new XmlSerializer(typeof(List<Flower>));
            using (var reader = new StreamReader(filePath))
            {
                return (List<Flower>)serializer.Deserialize(reader);
            }
        }
    }
    
}