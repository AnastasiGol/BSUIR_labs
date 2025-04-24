namespace Lab1;
using System.Xml.Serialization;

[Serializable]


[XmlInclude(typeof(Rose))]
[XmlInclude(typeof(Tulip))]
[XmlInclude(typeof(Peone))]
[XmlInclude(typeof(Orchid))]
[XmlInclude(typeof(Daisy))]
[XmlInclude(typeof(Cornflower))]
public abstract class Flower
{
    public string Name{get; set;}
    public int Height { get; set; }
    public string Color {get; set;}
    public int Price { get; set; }
    public string PictureURL { get; set; }
    
    public static int InstanceCount { get; private set; } = 0;

    public Flower()
    {
        InstanceCount++;
    }

    public abstract Flower Clone();

    
    
    static Flower() 
    {
        InstanceCount = 0;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Height: {Height} cm, Color: {Color}, Price: {Price} USD, ";
    }





}









