using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    public partial class Parrot : Pet
    {
        public bool CanTalk { get; set; }
        public bool IsSinging { get; set; }

        public Parrot() { }
        public Parrot(string name, int age, double weight, bool isClaustrophobic,
                      bool canTalk, bool isSinging)
            : base(name, age, weight, isClaustrophobic)
        {
            CanTalk = canTalk;
            IsSinging = isSinging;
        }

        public Parrot(string name, int age, double weight,
                      bool canTalk, bool isSinging)
            : this(name, age, weight, false, canTalk, isSinging)
        {
        }

        public override string GetSpecies()
        {
            return "Попугай";
        }

        public override string ToString()
        {
            return base.ToString() + $", умеет говорить: {(CanTalk ? "да" : "нет")}, поет: {(IsSinging ? "да" : "нет")}";
        }
    }
}