using System.Collections.Generic;

namespace PetShelter.Model.Core
{
    public interface IChangeable
    {
        void AddAnimal(Pet pet);
        bool RemoveAnimal(Pet pet);
        List<Pet> GetAnimals();
    }
}