using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShelter.Model.Core
{
    public partial class Shelter : ICountable, IFilter<Pet>, IChangeable, IReportable<Shelter>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool HasOpenArea { get; set; }

        private List<Pet> pets = new List<Pet>();

        public List<Pet> Pets
        {
            get { return pets; }
            set { pets = value ?? new List<Pet>(); }
        }

        public Shelter() { }

        public Shelter(string name, int capacity, bool hasOpenArea)
        {
            if (string.IsNullOrWhiteSpace(name))
                Name = "Без названия";
            else
                Name = name;
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

        public void AddPet(IEnumerable<Pet> petsToAdd)
        {
            foreach (var pet in petsToAdd)
            {
                AddPet(pet);
            }
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
            return new List<Pet>(pets);
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

        public static bool operator ==(Shelter a, Shelter b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Name == b.Name && a.Capacity == b.Capacity;
        }

        public static bool operator !=(Shelter a, Shelter b)
        {
            return !(a == b);
        }

        public static Shelter operator +(Shelter shelter, Pet pet)
        {
            shelter.AddPet(pet);
            return shelter;
        }

        public static Shelter operator -(Shelter shelter, Pet pet)
        {
            shelter.RemovePet(pet);
            return shelter;
        }

        public override bool Equals(object obj)
        {
            if (obj is Shelter other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return (Name?.GetHashCode() ?? 0) ^ Capacity.GetHashCode();
        }

        public void ProcessPets(Action<Pet> action)
        {
            foreach (var pet in pets)
            {
                action(pet);
            }
        }

        public List<Pet> FindPets(Predicate<Pet> predicate)
        {
            return pets.FindAll(predicate);
        }

        public int CalculateTotalWeight(Func<Pet, int> weightCalculator)
        {
            return pets.Sum(weightCalculator);
        }

        public string GenerateReport(Shelter data)
        {
            return $"Приют: {data.Name}, Вместимость: {data.Capacity}, Открытая площадка: {(data.HasOpenArea ? "да" : "нет")}, Питомцев: {data.Count()}";
        }

        public void DemonstrateCasts()
        {
            Animal animal = new Cat("Тест", 1, 2.0, false, true, true);
            Pet pet = animal as Pet;
            Cat cat = pet as Cat;

            ICountable countable = this;
            IFilter<Pet> filter = this;
            IChangeable changeable = this;
            IReportable<Shelter> reportable = this;

            int total = countable.Count();
            var filtered = filter.FilterByType(typeof(Cat));
            var animals = changeable.GetAnimals();
            string report = reportable.GenerateReport(this);
        }
    }
}