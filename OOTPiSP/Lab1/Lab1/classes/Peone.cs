namespace Lab1;

class Peone : GardenFlower
{
    public int PetalLayers { get; set; }
    public string FlowerSize {get; set;}
    public Peone()
    {
        PictureURL = "images//e5175a2b2fbb083c54c679a11d798f7b.jpg";
        Name = "Peone";
    }

    public override string ToString()
    {
        return base.ToString() + $"Petal Layers: {PetalLayers}, Flower Size: {FlowerSize}";
    }
    
    public override Flower Clone() => (Flower)MemberwiseClone();
}