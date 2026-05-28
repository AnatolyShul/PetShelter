using System;
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
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };
                string json = JsonConvert.SerializeObject(shelters, settings);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка сериализации JSON: {ex.Message}", ex);
            }
        }

        public override List<Shelter> Deserialize()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return new List<Shelter>();

                string json = File.ReadAllText(FilePath);
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };
                return JsonConvert.DeserializeObject<List<Shelter>>(json, settings) ?? new List<Shelter>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка десериализации JSON: {ex.Message}", ex);
            }
        }
    }
}