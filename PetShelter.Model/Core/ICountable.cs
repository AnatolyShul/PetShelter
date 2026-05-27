using System;

namespace PetShelter.Model.Core
{
    public interface ICountable
    {
        int Count();
        int Count(Type petType);
        int Percentage(Type petType);
    }
}