namespace FootballManager.Services
{

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using Contracts;
    public class ValidationService:IValidationService
    {
        public (bool, ICollection<string>) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            var errors = errorResult.Select(e=>e.ToString()).ToList();

            return (isValid, errors);
        }

        public (bool, DateTime) ValidateDate(string model)
        {
            DateTime date;

            var isValid = DateTime.TryParseExact(model, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            return (isValid, date);
        }
    }
}
