using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    public partial class Dog : Pet
    {
        public bool IsTrained { get; set; }
        public bool IsGuardDog { get; set; }

        public Dog() { }
        public Dog(string name, int age, double weight, bool isClaustrophobic,
                   bool isTrained, bool isGuardDog)
            : base(name, age, weight, isClaustrophobic)
        {
            IsTrained = isTrained;
            IsGuardDog = isGuardDog;
        }

        public Dog(string name, int age, double weight,
                   bool isTrained, bool isGuardDog)
            : this(name, age, weight, false, isTrained, isGuardDog)
        {
        }

        public override string GetSpecies()
        {
            return "Собака";
        }

        public override string ToString()
        {
            return base.ToString() + $", дрессирован: {(IsTrained ? "да" : "нет")}, сторожевой: {(IsGuardDog ? "да" : "нет")}";
        }
    }
}