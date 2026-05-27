using System.Collections.Generic;

namespace PetShelter.Model.Core
{
    public interface IChangeable<T> where T : Pet
    {
        void AddAnimal(T pet);
        bool RemoveAnimal(T pet);
        List<T> GetAnimalsByType();
    }
}