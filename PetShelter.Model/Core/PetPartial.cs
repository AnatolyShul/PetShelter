using System;

namespace PetShelter.Model.Core
{
    public partial class Pet
    {
        public Pet(string name, int age, double weight)
            : this(name, age, weight, false)
        {
        }

        public override string GetSpecies()
        {
            return "Неизвестный вид";
        }
    }
}