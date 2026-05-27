using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public class XmlDataSerializer : SerializerBase
    {
        public XmlDataSerializer(string filePath) : base(filePath) { }

        public override void Serialize(List<Shelter> shelters)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>));
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, shelters);
            }
        }

        public override List<Shelter> Deserialize()
        {
            if (!File.Exists(FilePath))
                return new List<Shelter>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>));
            using (StreamReader reader = new StreamReader(FilePath))
            {
                return (List<Shelter>)serializer.Deserialize(reader);
            }
        }
    }
}