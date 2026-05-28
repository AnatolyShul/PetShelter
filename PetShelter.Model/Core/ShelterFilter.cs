using System.Collections.Generic;
using System.Linq;

namespace PetShelter.Model.Core
{
    public partial class Shelter
    {
        public List<Pet> FilterByType(System.Type petType)
        {
            return pets.Where(p => p.GetType() == petType).ToList();
        }

        public List<Pet> FilterByType(System.Type petType, bool isClaustrophobic)
        {
            return pets.Where(p => p.GetType() == petType && p.IsClaustrophobic == isClaustrophobic).ToList();
        }

        public List<Pet> FilterByClaustrophobia(bool isClaustrophobic)
        {
            return pets.Where(p => p.IsClaustrophobic == isClaustrophobic).ToList();
        }

        public List<Pet> FilterByOpenAreaRequirement(bool needsOpenArea)
        {
            if (needsOpenArea)
                return pets.Where(p => p.IsClaustrophobic).ToList();
            else
                return pets.Where(p => !p.IsClaustrophobic).ToList();
        }
    }
}