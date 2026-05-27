using System;

namespace PetShelter.Model.Core
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public bool IsClaustrophobic { get; set; }

        protected Pet(string name, int age, double weight, bool isClaustrophobic)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Name = "Без имени";
            }
            else
            {
                Name = name;
            }
            Age = age;
            Weight = weight;
            IsClaustrophobic = isClaustrophobic;
        }

        public override string ToString()
        {
            return $"{Name}, {Age} лет, {Weight} кг";
        }
    }
}