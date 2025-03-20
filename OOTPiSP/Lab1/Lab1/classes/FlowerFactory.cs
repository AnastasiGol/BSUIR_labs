namespace Lab1;

public class FlowerFactory
{
    public static Flower CreateFlower(string flowerType, Dictionary<string, object> parameters)
    {
        Type type = Type.GetType($"Flower.{flowerType}");
        return (Flower)Activator.CreateInstance(type, parameters);
    }
}