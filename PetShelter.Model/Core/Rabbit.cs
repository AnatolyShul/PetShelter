namespace PetShelter.Model.Core
{
    public class Rabbit : Pet
    {
        public int EarLength { get; set; }
        public bool IsLitterTrained { get; set; }

        public Rabbit(string name, int age, double weight, bool isClaustrophobic,
                      int earLength, bool isLitterTrained)
            : base(name, age, weight, isClaustrophobic)
        {
            EarLength = earLength;
            IsLitterTrained = isLitterTrained;
        }

        public override string ToString()
        {
            return base.ToString() + $", длина ушей: {EarLength} см, приучен к лотку: {(IsLitterTrained ? "да" : "нет")}";
        }
    }
}