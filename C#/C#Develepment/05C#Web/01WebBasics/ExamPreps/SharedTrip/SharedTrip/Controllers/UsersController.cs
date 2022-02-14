using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Models;

namespace SharedTrip.Controllers
{
    public class UsersController :Controller
    {
        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            return View();
        }
    }
}