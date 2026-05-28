using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    public partial class Cat : Pet
    {
        public bool IsIndoor { get; set; }
        public bool IsFriendly { get; set; }

        public Cat() { }

        public Cat(string name, int age, double weight, bool isClaustrophobic,
                   bool isIndoor, bool isFriendly)
            : base(name, age, weight, isClaustrophobic)
        {
            IsIndoor = isIndoor;
            IsFriendly = isFriendly;
        }

        public Cat(string name, int age, double weight,
                   bool isIndoor, bool isFriendly)
            : this(name, age, weight, true, isIndoor, isFriendly)
        {
        }

        public override string GetSpecies()
        {
            return "Кошка";
        }

        public override string ToString()
        {
            return base.ToString() + $", домашний: {(IsIndoor ? "да" : "нет")}, дружелюбный: {(IsFriendly ? "да" : "нет")}";
        }
    }
}