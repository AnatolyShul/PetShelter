namespace PetShelter.Model.Core
{
    public interface IReportable<T>
    {
        string GenerateReport(T data);
    }
}