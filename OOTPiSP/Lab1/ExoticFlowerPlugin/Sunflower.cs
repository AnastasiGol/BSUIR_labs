using Lab1;

namespace ExoticFlowerPlugin;

public class Sunflower: Flower
{
    public Sunflower()
    {
        PictureURL = "images//sunflower.png";
        Name = "Sunflower";
        FlowerXmlSerializer.KnownTypes.Append(typeof(Sunflower));
    }
    public override Flower Clone() => (Flower)MemberwiseClone();
}
