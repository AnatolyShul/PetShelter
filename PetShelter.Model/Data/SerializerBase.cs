using System.Collections.Generic;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public abstract class SerializerBase
    {
        protected readonly string FilePath;

        protected SerializerBase(string filePath)
        {
            FilePath = filePath;
        }

        public abstract void Serialize(List<Shelter> shelters);
        public abstract List<Shelter> Deserialize();
    }
}