namespace Git.Services
{
    using Git.Contracts;
    using Git.ViewModels.ErrorViewModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ValidationService : IValidationService
    {
        public (bool, DateTime) ValidateDate(string model)
        {
            throw new NotImplementedException();
        }

        public (bool, ICollection<ErrorViewModel>) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            var errors = new List<ErrorViewModel>();

            if (errorResult.Count != 0)
            {
                 errors = errorResult.Select(e => new ErrorViewModel(e.ErrorMessage)).ToList();
            }
          
            return (isValid, errors);

        }
    }
}
