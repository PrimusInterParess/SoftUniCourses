using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RaceCorp.ModelBinder
{
    public class ExtractModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext ctx)
        {

            var value = ctx.ValueProvider.GetValue("created").FirstValue;

            if (DateTime.TryParse(value,out var valueAsDateTime))
            {   
                ctx.Result = ModelBindingResult.Success(valueAsDateTime.Year);

            }
            else
            {
                ctx.Result = ModelBindingResult.Failed();

            }

            return Task.CompletedTask;
        }

    }
}
