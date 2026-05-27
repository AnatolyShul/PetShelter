using System.Collections.Generic;

namespace PetShelter.Model.Core
{
    public interface IFilter<T> where T : Pet
    {
        List<T> FilterByType(System.Type petType);
        List<T> FilterByClaustrophobia(bool isClaustrophobic);
    }
}