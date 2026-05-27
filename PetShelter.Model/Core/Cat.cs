namespace PetShelter.Model.Core
{
    public class Cat : Pet
    {
        public string Breed { get; set; }
        public bool IsIndoor { get; set; }

        public Cat(string name, int age, double weight, bool isClaustrophobic,
                   string breed, bool isIndoor)
            : base(name, age, weight, isClaustrophobic)
        {
            Breed = breed;
            IsIndoor = isIndoor;
        }

        public override string ToString()
        {
            return base.ToString() + $", порода: {Breed}, домашний: {(IsIndoor ? "да" : "нет")}";
        }
    }
}