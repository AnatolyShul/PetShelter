using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    public partial class Monkey : Pet
    {
        public bool IsLongTailed { get; set; }
        public bool IsSocial { get; set; }

        public Monkey() { }
        public Monkey(string name, int age, double weight, bool isClaustrophobic,
                      bool isLongTailed, bool isSocial)
            : base(name, age, weight, isClaustrophobic)
        {
            IsLongTailed = isLongTailed;
            IsSocial = isSocial;
        }

        public Monkey(string name, int age, double weight,
                      bool isLongTailed, bool isSocial)
            : this(name, age, weight, true, isLongTailed, isSocial)
        {
        }

        public override string GetSpecies()
        {
            return "Обезьяна";
        }

        public override string ToString()
        {
            return base.ToString() + $", длиннохвостый: {(IsLongTailed ? "да" : "нет")}, социальный: {(IsSocial ? "да" : "нет")}";
        }
    }
}