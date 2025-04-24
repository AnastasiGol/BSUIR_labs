namespace Lab1;
using System.Xml.Serialization;

public class FlowerXmlSerializer
{
    private static readonly Type[] KnownTypes = new Type[]
    {
        typeof(Tulip), typeof(Rose), typeof(Peone), typeof(Orchid),
        typeof(Daisy), typeof(Cornflower)
    };

    public void Serialize(List<Flower> flowers, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<Flower>), KnownTypes);
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, flowers);
        }
    }
    
    public List<Flower> Deserialize(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Flower>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<Flower>)serializer.Deserialize(reader);
        }
    }
    
}