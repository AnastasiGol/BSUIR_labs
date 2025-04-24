namespace Lab1;
using System.Text.Json;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

public class FlowerJsonSerializer: ISerializer
{
    private static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { ResolverModifier }
            }
        };
    }

    // Добавляем информацию о всех наследниках Flower
    private static void ResolverModifier(JsonTypeInfo typeInfo)
    {
        if (typeInfo.Type == typeof(Flower))
        {
            typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$type", // это будет записано в JSON
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(Rose), "Rose"),
                    new JsonDerivedType(typeof(Tulip), "Tulip"),
                    new JsonDerivedType(typeof(Peone), "Peone"),
                    new JsonDerivedType(typeof(Orchid), "Orchid"),
                    new JsonDerivedType(typeof(Daisy), "Daisy"),
                    new JsonDerivedType(typeof(Cornflower), "Cornflower")
                }
            };
        }
    }

    public void Serialize(List<Flower> flowers, string filePath)
    {
        string json = JsonSerializer.Serialize(flowers, GetOptions());
        File.WriteAllText(filePath, json);
    }

    public List<Flower> Deserialize(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return System.Text.Json.JsonSerializer.Deserialize<List<Flower>>(json, GetOptions());
    }
}