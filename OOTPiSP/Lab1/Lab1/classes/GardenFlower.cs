namespace Lab1;
using System.Xml.Serialization;
[XmlInclude(typeof(Tulip))]
[XmlInclude(typeof(Rose))]
public abstract class GardenFlower : Flower
{
    public string Season{get;set;}
    public string Pruning{get;set;}
    
    public override string ToString()
    {
        return base.ToString() + $"Season: {Season}, Pruning: {Pruning}, ";
    }


}