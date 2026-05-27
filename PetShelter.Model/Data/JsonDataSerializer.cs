using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public class JsonDataSerializer : SerializerBase
    {
        public JsonDataSerializer(string filePath) : base(filePath) { }

        public override void Serialize(List<Shelter> shelters)
        {
            string json = JsonConvert.SerializeObject(shelters, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public override List<Shelter> Deserialize()
        {
            if (!File.Exists(FilePath))
                return new List<Shelter>();

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Shelter>>(json);
        }
    }
}