using Microsoft.AspNetCore.Mvc;
using RaceCorp.Models.InputModels;
namespace RaceCorp.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Add(InputModel model)
        {


            return this.Json(model);
        }
    }
}
