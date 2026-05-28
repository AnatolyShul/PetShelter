using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public class XmlDataSerializer : SerializerBase
    {
        private static readonly Type[] ShelterTypes = new Type[]
        {
            typeof(Shelter),
            typeof(Pet),
            typeof(Cat),
            typeof(Dog),
            typeof(Rabbit),
            typeof(Parrot),
            typeof(Monkey),
            typeof(Animal)
        };

        public XmlDataSerializer(string filePath) : base(filePath) { }

        public override void Serialize(List<Shelter> shelters)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>), ShelterTypes);
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    serializer.Serialize(writer, shelters);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка сериализации XML: {ex.Message}", ex);
            }
        }

        public override List<Shelter> Deserialize()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<Shelter>();

                XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>), ShelterTypes);
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    return (List<Shelter>)serializer.Deserialize(reader) ?? new List<Shelter>();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка десериализации XML: {ex.Message}", ex);
            }
        }
    }
}