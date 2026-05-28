using System.Collections.Generic;
using PetShelter.Model.Core;

namespace PetShelter.Model.Data
{
    public static class DataGenerator
    {
        public static List<Shelter> GenerateData()
        {
            var shelters = new List<Shelter>();

            var shelter1 = new Shelter("Солнечный приют", 10, true);
            shelter1.AddPet(new Cat("Мурзик", 3, 4.5, true, true, true));
            shelter1.AddPet(new Dog("Бобик", 5, 12.0, false, true, true));
            shelter1.AddPet(new Rabbit("Банни", 2, 1.2, false, true, true));
            shelter1.AddPet(new Parrot("Кеша", 4, 0.3, false, true, true));
            shelter1.AddPet(new Monkey("Чи-Чи", 3, 8.5, false, true, true));
            shelters.Add(shelter1);

            var shelter2 = new Shelter("Домик на дереве", 8, false);
            shelter2.AddPet(new Cat("Вася", 2, 3.8, false, false, false));
            shelter2.AddPet(new Dog("Шарик", 4, 15.0, false, false, false));
            shelter2.AddPet(new Rabbit("Пушок", 1, 0.9, false, false, false));
            shelter2.AddPet(new Parrot("Гоша", 2, 0.25, false, false, false));
            shelters.Add(shelter2);

            var shelter3 = new Shelter("Зелёный луг", 15, true);
            shelter3.AddPet(new Dog("Рекс", 6, 20.0, false, true, true));
            shelter3.AddPet(new Cat("Леопольд", 7, 5.0, false, true, true));
            shelter3.AddPet(new Rabbit("Ушастик", 3, 1.5, false, true, true));
            shelter3.AddPet(new Monkey("Бонзо", 5, 12.0, false, true, true));
            shelter3.AddPet(new Parrot("Ара", 10, 0.4, false, true, true));
            shelter3.AddPet(new Dog("Тузик", 2, 8.0, false, false, false));
            shelters.Add(shelter3);

            return shelters;
        }
    }
}