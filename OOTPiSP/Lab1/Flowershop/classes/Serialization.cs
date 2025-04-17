namespace Flowershop
{
    using System.Text.Json;
    using System.Xml.Serialization;
    using System.IO;
    using System;

    /*internal class Serialization
    {
        // XML, JSON
        private SerializationType type;
        private string fileName;

        public enum SerializationType
        {
            JSON,
            XML
        }

        public class Serializer
        {
            private SerializationType type;
            private string fileName;

            public Serializer(SerializationType type, string fileName)
            {
                this.type = type;
                this.fileName = fileName;
            }

            public void Save(Flower flower)
            {
                switch (type)
                {
                    case SerializationType.JSON:
                        SerializeToJson(flower);
                        break;
                    case SerializationType.XML:
                        SerializeToXml(flower);
                        break;
                    default:
                        throw new InvalidOperationException("Неизвестный тип сериализации.");
                }
            }

            public Flower Load()
            {
                switch (type)
                {
                    case SerializationType.JSON:
                        return DeserializeFromJson();
                    case SerializationType.XML:
                        return DeserializeFromXml();
                    default:
                        throw new InvalidOperationException("Неизвестный тип сериализации.");
                }
            }

        }

        private void SerializeToJson(Flower flower)
        {
            string jsonString = JsonSerializer.Serialize(flower);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("Объект сериализован в JSON!");
        }

        private Flower DeserializeFromJson()
        {
            string jsonString = File.ReadAllText(fileName);
            Flower flower = JsonSerializer.Deserialize<Flower>(jsonString);
            Console.WriteLine("Объект десериализован из JSON!");
            return flower;
        }

        private void SerializeToXml(Flower flower)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Flower));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, flower);
                Console.WriteLine("Объект сериализован в XML!");
            }
        }

        private Flower DeserializeFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Flower));
            using (StreamReader reader = new StreamReader(fileName))
            {
                Flower flower = (Flower)serializer.Deserialize(reader);
                Console.WriteLine("Объект десериализован из XML!");
                return flower;
            }
        }
    }*/
}
