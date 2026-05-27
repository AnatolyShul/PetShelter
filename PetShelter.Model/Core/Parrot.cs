namespace PetShelter.Model.Core
{
    public class Parrot : Pet
    {
        public int VocabularySize { get; set; }
        public int Wingspan { get; set; }

        public Parrot(string name, int age, double weight, bool isClaustrophobic,
                      int vocabularySize, int wingspan)
            : base(name, age, weight, isClaustrophobic)
        {
            VocabularySize = vocabularySize;
            Wingspan = wingspan;
        }

        public override string ToString()
        {
            return base.ToString() + $", знает слов: {VocabularySize}, размах крыльев: {Wingspan} см";
        }
    }
}