using Microsoft.AspNetCore.Mvc;
using RaceCorp.ModelBinder;

namespace RaceCorp.Models.InputModels
{
    public class InputModel
    {
        public DateTime Created { get; set; }

        [ModelBinder(typeof(ExtractModelBinder))]
        public int Year { get; set; }
    }
}
