using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    [XmlInclude(typeof(Cat))]
    [XmlInclude(typeof(Dog))]
    [XmlInclude(typeof(Rabbit))]
    [XmlInclude(typeof(Parrot))]
    [XmlInclude(typeof(Monkey))]
    public abstract partial class Pet : Animal
    {
        public bool IsClaustrophobic { get; set; }

        public Pet() { }

        public Pet(string name, int age, double weight, bool isClaustrophobic)
            : base(name, age, weight)
        {
            IsClaustrophobic = isClaustrophobic;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}