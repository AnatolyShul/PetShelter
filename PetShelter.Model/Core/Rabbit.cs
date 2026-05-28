using System;
using System.Xml.Serialization;

namespace PetShelter.Model.Core
{
    [Serializable]
    public partial class Rabbit : Pet
    {
        public bool IsLitterTrained { get; set; }
        public bool IsLongHaired { get; set; }

        public Rabbit() { }
        public Rabbit(string name, int age, double weight, bool isClaustrophobic,
                      bool isLitterTrained, bool isLongHaired)
            : base(name, age, weight, isClaustrophobic)
        {
            IsLitterTrained = isLitterTrained;
            IsLongHaired = isLongHaired;
        }

        public Rabbit(string name, int age, double weight,
                      bool isLitterTrained, bool isLongHaired)
            : this(name, age, weight, false, isLitterTrained, isLongHaired)
        {
        }

        public override string GetSpecies()
        {
            return "Кролик";
        }

        public override string ToString()
        {
            return base.ToString() + $", приучен к лотку: {(IsLitterTrained ? "да" : "нет")}, длинношерстный: {(IsLongHaired ? "да" : "нет")}";
        }
    }
}