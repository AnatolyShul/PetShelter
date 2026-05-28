using System;

namespace PetShelter.Model.Core
{
    [Serializable]
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public Animal() { }

        public Animal(string name, int age, double weight)
        {
            if (string.IsNullOrWhiteSpace(name))
                Name = "Без имени";
            else
                Name = name;
            Age = age;
            Weight = weight;
        }

        public abstract string GetSpecies();

        public override string ToString()
        {
            return $"{Name}, {Age} лет, {Weight} кг";
        }
    }
}