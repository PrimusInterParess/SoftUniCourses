namespace Git.Contracts
{
    using System;
    using System.Collections.Generic;
    using Git.ViewModels.ErrorViewModel;
    public interface IValidationService
    {
        (bool, ICollection<ErrorViewModel>) ValidateModel(object model);

        (bool, DateTime) ValidateDate(string model);
    }
}
