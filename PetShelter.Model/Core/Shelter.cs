using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShelter.Model.Core
{
    public partial class Shelter : ICountable, IFilter<Pet>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool HasOpenArea { get; set; }

        private List<Pet> pets = new List<Pet>();

        public Shelter(string name, int capacity, bool hasOpenArea)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Name = "Без названия";
            }
            else
            {
                Name = name;
            }
            Capacity = capacity;
            HasOpenArea = hasOpenArea;
        }

        public void AddPet(Pet pet)
        {
            if (pets.Count >= Capacity)
                throw new InvalidOperationException("Приют переполнен!");

            if (pet.IsClaustrophobic && !HasOpenArea)
                throw new InvalidOperationException("Клаустрофобное животное нельзя поместить в закрытый приют!");

            pets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            pets.Remove(pet);
        }

        public void RemovePetAt(int index)
        {
            if (index >= 0 && index < pets.Count)
                pets.RemoveAt(index);
        }

        public List<Pet> GetPets()
        {
            return new List<Pet> (pets);
        }

        public Pet GetPetAt(int index)
        {
            if (index >= 0 && index < pets.Count)
                return pets[index];
            return null;
        }

        public int Count()
        {
            return pets.Count;
        }

        public int Count(System.Type petType)
        {
            return pets.Count(p => p.GetType() == petType);
        }

        public int Percentage(System.Type petType)
        {
            if (pets.Count == 0) return 0;
            return (int)((double)Count(petType) / pets.Count * 100);
        }

        
    }
}