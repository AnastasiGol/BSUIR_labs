namespace Lab1;

public class Rose : GardenFlower
{
    public bool HasThorns{ get; set; }
    public string FragranceType{ get; set; }

    public Rose()
    {
        PictureURL = "images//6ba07a687882de49c4d3a48d3ea762bc.jpg";
        Name = "Rose";
    }

    public override string ToString()
    {
        return base.ToString() + $"Thorns: {HasThorns}, Type of Fragrance: {FragranceType}";
    }
    
    public override Flower Clone() => (Flower)MemberwiseClone();


}