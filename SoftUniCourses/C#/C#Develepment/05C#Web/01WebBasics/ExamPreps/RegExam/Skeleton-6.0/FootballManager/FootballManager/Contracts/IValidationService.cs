namespace FootballManager.Contracts
{
    public interface IValidationService
    {
        (bool, ICollection<string>) ValidateModel(object model);

        (bool, DateTime) ValidateDate(string model);
    }
}
