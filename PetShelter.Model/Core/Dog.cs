namespace PetShelter.Model.Core
{
    public class Dog : Pet
    {
        public string Breed { get; set; }
        public bool IsTrained { get; set; }

        public Dog(string name, int age, double weight, bool isClaustrophobic,
                   string breed, bool isTrained)
            : base(name, age, weight, isClaustrophobic)
        {
            Breed = breed;
            IsTrained = isTrained;
        }

        public override string ToString()
        {
            return base.ToString() + $", порода: {Breed}, дрессирован: {(IsTrained ? "да" : "нет")}";
        }
    }
}