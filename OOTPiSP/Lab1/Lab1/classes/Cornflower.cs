namespace Lab1;

public class Cornflower : WildFlower
{
    public bool IsEdible { get; set; }
    public bool WildGrowthRegion { get; set; }
    public Cornflower()
    {
        PictureURL = "images//6feec4bd6f6e12ca440b1ee78d588d74.jpg";
        Name = "Cornflower";
    }

    public override string ToString()
    {
        return base.ToString() + $"Edible : {IsEdible}, WildGrowth : {WildGrowthRegion}";
    }

    /*public override Flower Clone()
    {
        return (Flower)MemberwiseClone();
    }*/

    public override Flower Clone() => (Flower)MemberwiseClone();
}