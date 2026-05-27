namespace PetShelter.Model.Core
{
    public class Monkey : Pet
    {
        public string Species { get; set; }
        public int TailLength { get; set; }

        public Monkey(string name, int age, double weight, bool isClaustrophobic,
                      string species, int tailLength)
            : base(name, age, weight, isClaustrophobic)
        {
            Species = species;
            TailLength = tailLength;
        }

        public override string ToString()
        {
            return base.ToString() + $", вид: {Species}, длина хвоста: {TailLength} см";
        }
    }
}