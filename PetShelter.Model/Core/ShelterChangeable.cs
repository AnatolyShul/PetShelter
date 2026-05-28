using System.Collections.Generic;

namespace PetShelter.Model.Core
{
    public partial class Shelter : IChangeable
    {
        void IChangeable.AddAnimal(Pet pet)
        {
            AddPet(pet);
        }

        bool IChangeable.RemoveAnimal(Pet pet)
        {
            if (pets.Contains(pet))
            {
                RemovePet(pet);
                return true;
            }
            return false;
        }

        List<Pet> IChangeable.GetAnimals()
        {
            return GetPets();
        }
    }
}