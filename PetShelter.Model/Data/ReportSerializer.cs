using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public abstract class ReportSerializerBase
    {
        protected readonly string DirectoryPath;

        protected ReportSerializerBase(string directoryPath)
        {
            DirectoryPath = directoryPath;
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);
        }

        public abstract void SaveReport(string fileName, List<Pet> pets);
        public abstract List<Pet> LoadReport(string fileName);
        public abstract string[] GetReportFiles();

        public static ReportSerializerBase CreateSerializer(string directoryPath, bool useJson)
        {
            if (useJson)
                return new JsonReportSerializer(directoryPath);
            return new XmlReportSerializer(directoryPath);
        }
    }

    public class JsonReportSerializer : ReportSerializerBase
    {
        public JsonReportSerializer(string directoryPath) : base(directoryPath) { }

        public override void SaveReport(string fileName, List<Pet> pets)
        {
            string path = Path.Combine(DirectoryPath, fileName + ".json");
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(pets, settings);
            File.WriteAllText(path, json);
        }

        public override List<Pet> LoadReport(string fileName)
        {
            string path = Path.Combine(DirectoryPath, fileName + ".json");
            if (!File.Exists(path)) return new List<Pet>();
            string json = File.ReadAllText(path);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            return JsonConvert.DeserializeObject<List<Pet>>(json, settings) ?? new List<Pet>();
        }

        public override string[] GetReportFiles()
        {
            return Directory.GetFiles(DirectoryPath, "*.json");
        }
    }

    public class XmlReportSerializer : ReportSerializerBase
    {
        private static readonly Type[] PetTypes = new Type[]
        {
            typeof(Pet),
            typeof(Cat),
            typeof(Dog),
            typeof(Rabbit),
            typeof(Parrot),
            typeof(Monkey),
            typeof(Animal)
        };

        public XmlReportSerializer(string directoryPath) : base(directoryPath) { }

        public override void SaveReport(string fileName, List<Pet> pets)
        {
            string path = Path.Combine(DirectoryPath, fileName + ".xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pet>), PetTypes);
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, pets);
            }
        }

        public override List<Pet> LoadReport(string fileName)
        {
            string path = Path.Combine(DirectoryPath, fileName + ".xml");
            if (!File.Exists(path)) return new List<Pet>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Pet>), PetTypes);
            using (StreamReader reader = new StreamReader(path))
            {
                return (List<Pet>)serializer.Deserialize(reader) ?? new List<Pet>();
            }
        }

        public override string[] GetReportFiles()
        {
            return Directory.GetFiles(DirectoryPath, "*.xml");
        }
    }
}