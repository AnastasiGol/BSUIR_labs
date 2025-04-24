namespace Lab1;
using System.Xml.Serialization;
[XmlInclude(typeof(Tulip))]
public class Tulip : GardenFlower
{
    
    public bool IsBulbous{ get; set; } = false;
    public string BloomPeriod{ get; set; } = string.Empty;
    
    public Tulip()
    {
        PictureURL = "images//c50af48d851c3c830c30a9da4cc45c7b.png";
        Name = "Tulip";
    }

    public override string ToString()
    {
        return base.ToString() + $"Bulbous: {IsBulbous}, Bloom Period: {BloomPeriod}";
    }
    
    public override Flower Clone() => (Flower)MemberwiseClone();


}