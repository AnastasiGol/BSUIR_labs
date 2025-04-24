namespace Lab1;

public class Orchid : GardenFlower
{
    public string GrowthType{ get; set; }
    public string HumidityPreference{ get; set; }
    public Orchid()
    {
        PictureURL = "images//orhideya.png";
        Name = "Orchid";
    }

    public override string ToString()
    {
        return base.ToString() + $"Type of Growth: {GrowthType}, Humidity: {HumidityPreference}";
    }
    
    public override Flower Clone() => (Flower)MemberwiseClone();
}